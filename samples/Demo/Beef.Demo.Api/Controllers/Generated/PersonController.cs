/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Beef;
using Beef.AspNetCore.WebApi;
using Beef.Entities;
using Beef.Demo.Business;
using Beef.Demo.Common.Entities;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Api.Controllers
{
    /// <summary>
    /// Provides the <see cref="Person"/> Web API functionality.
    /// </summary>
    [AllowAnonymous]
    [Route("api/v1/persons")]
    public partial class PersonController : ControllerBase
    {
        private readonly IPersonManager _manager;
        private readonly IPersonManager _personManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController"/> class.
        /// </summary>
        /// <param name="manager">The <see cref="IPersonManager"/>.</param>
        /// <param name="personManager">The <see cref="IPersonManager"/>.</param>
        public PersonController(IPersonManager manager, IPersonManager personManager)
            { _manager = Check.NotNull(manager, nameof(manager)); _personManager = Check.NotNull(personManager, nameof(personManager)); PersonControllerCtor(); }

        partial void PersonControllerCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Creates a new <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="Person"/>.</param>
        /// <returns>The created <see cref="Person"/>.</returns>
        [AllowAnonymous]
        [HttpPost("")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.Created)]
        public IActionResult Create([FromBody] Person value)
        {
            return new WebApiPost<Person>(this, () => _manager.CreateAsync(WebApiActionBase.Value(value)),
                operationType: OperationType.Create, statusCode: HttpStatusCode.Created, alternateStatusCode: null);
        }

        /// <summary>
        /// Deletes the specified <see cref="Person"/>.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        [AllowAnonymous]
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Delete(Guid id)
        {
            return new WebApiDelete(this, () => _manager.DeleteAsync(id),
                operationType: OperationType.Delete, statusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Gets the specified <see cref="Person"/>.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The selected <see cref="Person"/> where found.</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(Guid id)
        {
            return new WebApiGet<Person?>(this, () => _manager.GetAsync(id),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Updates an existing <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="Person"/>.</param>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The updated <see cref="Person"/>.</returns>
        [AllowAnonymous]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public IActionResult Update([FromBody] Person value, Guid id)
        {
            return new WebApiPut<Person>(this, () => _manager.UpdateAsync(WebApiActionBase.Value(value), id),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);
        }

        /// <summary>
        /// Patches an existing <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="JToken"/> that contains the patch content for the <see cref="Person"/>.</param>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The patched <see cref="Person"/>.</returns>
        [AllowAnonymous]
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public IActionResult Patch([FromBody] JToken value, Guid id)
        {
            return new WebApiPatch<Person>(this, value, () => _manager.GetAsync(id), (__value) => _manager.UpdateAsync(__value, id),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);
        }

        /// <summary>
        /// Gets the <see cref="PersonCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <returns>The <see cref="PersonCollection"/></returns>
        [AllowAnonymous]
        [HttpGet("all")]
        [ProducesResponseType(typeof(PersonCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetAll()
        {
            return new WebApiGet<PersonCollectionResult, PersonCollection, Person>(this, () => _manager.GetAllAsync(WebApiQueryString.CreatePagingArgs(this)),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Gets the <see cref="PersonCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <returns>The <see cref="PersonCollection"/></returns>
        [AllowAnonymous]
        [HttpGet("allnopaging")]
        [ProducesResponseType(typeof(PersonCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetAll2()
        {
            return new WebApiGet<PersonCollectionResult, PersonCollection, Person>(this, () => _manager.GetAll2Async(),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Gets the <see cref="PersonCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="firstName">The First Name.</param>
        /// <param name="lastName">The Last Name.</param>
        /// <param name="genders">The Genders (see <see cref="RefDataNamespace.Gender"/>).</param>
        /// <returns>The <see cref="PersonCollection"/></returns>
        [AllowAnonymous]
        [HttpGet("")]
        [ProducesResponseType(typeof(PersonCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetByArgs(string? firstName = default, string? lastName = default, List<string>? genders = default)
        {
            var args = new PersonArgs { FirstName = firstName, LastName = lastName, GendersSids = genders };
            return new WebApiGet<PersonCollectionResult, PersonCollection, Person>(this, () => _manager.GetByArgsAsync(args, WebApiQueryString.CreatePagingArgs(this)),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Gets the <see cref="PersonDetailCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="firstName">The First Name.</param>
        /// <param name="lastName">The Last Name.</param>
        /// <param name="genders">The Genders (see <see cref="RefDataNamespace.Gender"/>).</param>
        /// <returns>The <see cref="PersonDetailCollection"/></returns>
        [AllowAnonymous]
        [HttpGet("argsdetail")]
        [ProducesResponseType(typeof(PersonDetailCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetDetailByArgs(string? firstName = default, string? lastName = default, List<string>? genders = default)
        {
            var args = new PersonArgs { FirstName = firstName, LastName = lastName, GendersSids = genders };
            return new WebApiGet<PersonDetailCollectionResult, PersonDetailCollection, PersonDetail>(this, () => _manager.GetDetailByArgsAsync(args, WebApiQueryString.CreatePagingArgs(this)),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Merge first <see cref="Person"/> into second.
        /// </summary>
        /// <param name="fromId">The from <see cref="Person"/> identifier.</param>
        /// <param name="toId">The to <see cref="Person"/> identifier.</param>
        /// <returns>A resultant <see cref="Person"/>.</returns>
        [AllowAnonymous]
        [HttpPost("merge")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public IActionResult Merge(Guid fromId, Guid toId)
        {
            return new WebApiPost<Person>(this, () => _manager.MergeAsync(fromId, toId),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);
        }

        /// <summary>
        /// Mark <see cref="Person"/>.
        /// </summary>
        [AllowAnonymous]
        [HttpPost("mark")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public IActionResult Mark()
        {
            return new WebApiPost(this, () => _manager.MarkAsync(),
                operationType: OperationType.Update, statusCode: HttpStatusCode.Accepted);
        }

        /// <summary>
        /// Get <see cref="Person"/> at specified <see cref="MapCoordinates"/>.
        /// </summary>
        /// <param name="coordinates">The Coordinates (see <see cref="Common.Entities.MapCoordinates"/>).</param>
        /// <returns>A resultant <see cref="MapCoordinates"/>.</returns>
        [AllowAnonymous]
        [HttpPost("map")]
        [ProducesResponseType(typeof(MapCoordinates), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Map(string? coordinates = default)
        {
            var args = new MapArgs { Coordinates = new MapCoordinatesToStringConverter().ConvertToSrce(coordinates) };
            return new WebApiPost<MapCoordinates>(this, () => _manager.MapAsync(args),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Get no arguments.
        /// </summary>
        /// <returns>The selected <see cref="Person"/> where found.</returns>
        [AllowAnonymous]
        [HttpGet("noargsforme")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetNoArgs()
        {
            return new WebApiGet<Person?>(this, () => _manager.GetNoArgsAsync(),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Gets the specified <see cref="PersonDetail"/>.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The selected <see cref="PersonDetail"/> where found.</returns>
        [AllowAnonymous]
        [HttpGet("{id}/detail")]
        [ProducesResponseType(typeof(PersonDetail), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetDetail(Guid id)
        {
            return new WebApiGet<PersonDetail?>(this, () => _manager.GetDetailAsync(id),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Updates an existing <see cref="PersonDetail"/>.
        /// </summary>
        /// <param name="value">The <see cref="PersonDetail"/>.</param>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The updated <see cref="PersonDetail"/>.</returns>
        [AllowAnonymous]
        [HttpPut("{id}/detail")]
        [ProducesResponseType(typeof(PersonDetail), (int)HttpStatusCode.OK)]
        public IActionResult UpdateDetail([FromBody] PersonDetail value, Guid id)
        {
            return new WebApiPut<PersonDetail>(this, () => _manager.UpdateDetailAsync(WebApiActionBase.Value(value), id),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);
        }

        /// <summary>
        /// Patches an existing <see cref="PersonDetail"/>.
        /// </summary>
        /// <param name="value">The <see cref="JToken"/> that contains the patch content for the <see cref="PersonDetail"/>.</param>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The patched <see cref="PersonDetail"/>.</returns>
        [AllowAnonymous]
        [HttpPatch("{id}/detail")]
        [ProducesResponseType(typeof(PersonDetail), (int)HttpStatusCode.OK)]
        public IActionResult PatchDetail([FromBody] JToken value, Guid id)
        {
            return new WebApiPatch<PersonDetail>(this, value, () => _manager.GetDetailAsync(id), (__value) => _personManager.UpdateDetailAsync(__value, id),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);
        }

        /// <summary>
        /// Actually validating the FromBody parameter generation.
        /// </summary>
        /// <param name="person">The Person (see <see cref="Common.Entities.Person"/>).</param>
        [AllowAnonymous]
        [HttpPost("fromBody")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult Add([FromBody] Person person)
        {
            return new WebApiPost(this, () => _manager.AddAsync(person),
                operationType: OperationType.Unspecified, statusCode: HttpStatusCode.Created);
        }

        /// <summary>
        /// Get Null.
        /// </summary>
        /// <param name="name">The Name.</param>
        /// <param name="names">The Names.</param>
        /// <returns>A resultant <see cref="Person"/>.</returns>
        [AllowAnonymous]
        [HttpGet("null")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetNull(string? name, List<string>? names = default)
        {
            return new WebApiGet<Person?>(this, () => _manager.GetNullAsync(name, names),
                operationType: OperationType.Unspecified, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Gets the <see cref="PersonCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="firstName">The First Name.</param>
        /// <param name="lastName">The Last Name.</param>
        /// <param name="genders">The Genders (see <see cref="RefDataNamespace.Gender"/>).</param>
        /// <returns>The <see cref="PersonCollection"/></returns>
        [AllowAnonymous]
        [HttpGet("args")]
        [ProducesResponseType(typeof(PersonCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetByArgsWithEf(string? firstName = default, string? lastName = default, List<string>? genders = default)
        {
            var args = new PersonArgs { FirstName = firstName, LastName = lastName, GendersSids = genders };
            return new WebApiGet<PersonCollectionResult, PersonCollection, Person>(this, () => _manager.GetByArgsWithEfAsync(args, WebApiQueryString.CreatePagingArgs(this)),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Throw Error.
        /// </summary>
        [AllowAnonymous]
        [HttpPost("error")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult ThrowError()
        {
            return new WebApiPost(this, () => _manager.ThrowErrorAsync(),
                operationType: OperationType.Unspecified, statusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Gets the specified <see cref="Person"/>.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The selected <see cref="Person"/> where found.</returns>
        [AllowAnonymous]
        [HttpGet("ef/{id}")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetWithEf(Guid id)
        {
            return new WebApiGet<Person?>(this, () => _manager.GetWithEfAsync(id),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Creates a new <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="Person"/>.</param>
        /// <returns>The created <see cref="Person"/>.</returns>
        [AllowAnonymous]
        [HttpPost("ef")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.Created)]
        public IActionResult CreateWithEf([FromBody] Person value)
        {
            return new WebApiPost<Person>(this, () => _manager.CreateWithEfAsync(WebApiActionBase.Value(value)),
                operationType: OperationType.Create, statusCode: HttpStatusCode.Created, alternateStatusCode: null);
        }

        /// <summary>
        /// Updates an existing <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="Person"/>.</param>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The updated <see cref="Person"/>.</returns>
        [AllowAnonymous]
        [HttpPut("ef/{id}")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public IActionResult UpdateWithEf([FromBody] Person value, Guid id)
        {
            return new WebApiPut<Person>(this, () => _manager.UpdateWithEfAsync(WebApiActionBase.Value(value), id),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);
        }

        /// <summary>
        /// Deletes the specified <see cref="Person"/>.
        /// </summary>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        [AllowAnonymous]
        [HttpDelete("ef/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult DeleteWithEf(Guid id)
        {
            return new WebApiDelete(this, () => _manager.DeleteWithEfAsync(id),
                operationType: OperationType.Delete, statusCode: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Patches an existing <see cref="Person"/>.
        /// </summary>
        /// <param name="value">The <see cref="JToken"/> that contains the patch content for the <see cref="Person"/>.</param>
        /// <param name="id">The <see cref="Person"/> identifier.</param>
        /// <returns>The patched <see cref="Person"/>.</returns>
        [AllowAnonymous]
        [HttpPatch("ef/{id}")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        public IActionResult PatchWithEf([FromBody] JToken value, Guid id)
        {
            return new WebApiPatch<Person>(this, value, () => _manager.GetAsync(id), (__value) => _manager.UpdateAsync(__value, id),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);
        }
    }
}

#pragma warning restore IDE0005
#nullable restore