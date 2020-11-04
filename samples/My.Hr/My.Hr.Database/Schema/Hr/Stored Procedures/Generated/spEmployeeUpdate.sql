CREATE PROCEDURE [Hr].[spEmployeeUpdate]
   @EmployeeId AS UNIQUEIDENTIFIER
  ,@Email AS NVARCHAR(250) NULL = NULL
  ,@FirstName AS NVARCHAR(100) NULL = NULL
  ,@LastName AS NVARCHAR(100) NULL = NULL
  ,@GenderCode AS NVARCHAR(50) NULL = NULL
  ,@Birthday AS DATE NULL = NULL
  ,@StartDate AS DATE NULL = NULL
  ,@TerminationDate AS DATE NULL = NULL
  ,@TerminationReasonCode AS NVARCHAR(50) NULL = NULL
  ,@PhoneNo AS NVARCHAR(50) NULL = NULL
  ,@AddressJson AS NVARCHAR(500) NULL = NULL
  ,@RowVersion AS TIMESTAMP
  ,@UpdatedBy AS NVARCHAR(250) NULL = NULL
  ,@UpdatedDate AS DATETIME2 NULL = NULL
  ,@EmergencyContactList AS [Hr].[udtEmergencyContactList] READONLY
  ,@ReselectRecord AS BIT = 0
AS
BEGIN
  /*
   * This file is automatically generated; any changes will be lost. 
   */
 
  SET NOCOUNT ON;
  
  BEGIN TRY
    -- Wrap in a transaction.
    BEGIN TRANSACTION

    -- Set audit details, etc.
    EXEC @UpdatedDate = fnGetTimestamp @UpdatedDate
    EXEC @UpdatedBy = fnGetUsername @UpdatedBy

    -- Check exists.
    DECLARE @PrevRowVersion BINARY(8)
    SET @PrevRowVersion = (SELECT TOP 1 x.[RowVersion] FROM [Hr].[Employee] AS x WHERE x.[EmployeeId] = @EmployeeId)
    IF @PrevRowVersion IS NULL
    BEGIN
      EXEC spThrowNotFoundException
    END

    -- Check concurrency (where provided).
    IF @RowVersion IS NULL OR @PrevRowVersion <> @RowVersion
    BEGIN
      EXEC spThrowConcurrencyException
    END

    -- Update the record.
    UPDATE [Hr].[Employee] SET
         [Email] = @Email
        ,[FirstName] = @FirstName
        ,[LastName] = @LastName
        ,[GenderCode] = @GenderCode
        ,[Birthday] = @Birthday
        ,[StartDate] = @StartDate
        ,[TerminationDate] = @TerminationDate
        ,[TerminationReasonCode] = @TerminationReasonCode
        ,[PhoneNo] = @PhoneNo
        ,[AddressJson] = @AddressJson
        ,[UpdatedBy] = @UpdatedBy
        ,[UpdatedDate] = @UpdatedDate
      WHERE [EmployeeId] = @EmployeeId

    -- Execute additional statements.
    EXEC [Hr].[spEmergencyContactMerge] @EmployeeId, @EmergencyContactList

    -- Commit the transaction.
    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
    -- Rollback transaction and rethrow error.
    IF @@TRANCOUNT > 0
      ROLLBACK TRANSACTION;

    THROW;
  END CATCH
  
  -- Reselect record.
  IF @ReselectRecord = 1
  BEGIN
    EXEC [Hr].[spEmployeeGet] @EmployeeId
  END
END