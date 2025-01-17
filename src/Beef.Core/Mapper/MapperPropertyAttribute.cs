﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using System;

namespace Beef.Mapper
{
    /// <summary>
    /// Represents an attribute for defining property characteristics for <b>Beef.Data.Database.DatabaseMapper</b> mapping.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MapperPropertyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperPropertyAttribute"/> class.
        /// </summary>
        /// <param name="name">The property name.</param>
        public MapperPropertyAttribute(string name) => Name = Check.NotEmpty(name, nameof(name));

        /// <summary>
        /// Gets the property name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Indicates whether the property forms part of the unique (primary) key. 
        /// </summary>
        public bool IsUniqueKey { get; set; }

        /// <summary>
        /// Indicates whether the property value is auto-generated on create (defaults to <c>true</c>); used where <see cref="IsUniqueKey"/> is <c>true</c>. 
        /// </summary>
        public bool IsUniqueKeyAutoGeneratedOnCreate { get; protected set; } = true;

        /// <summary>
        /// Gets or sets the <see cref="Converters.IPropertyMapperConverter"/> <see cref="Type"/>.
        /// </summary>
        public Type? ConverterType { get; set; }

        /// <summary>
        /// Gets or sets the <b>Beef.Data.Database.Mapping.IEntityMapperBase (Beef.Data.Database)</b> <see cref="Type"/> for the complex property type.
        /// </summary>
        public Type? MapperType { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Mapper.OperationTypes"/> selection to enable inclusion or exclusion of property (default to <see cref="OperationTypes.Any"/>).
        /// </summary>
        public OperationTypes OperationTypes { get; set; } = OperationTypes.Any;
    }
}