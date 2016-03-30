﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace PDS.Framework
{
    /// <summary>
    /// Provides access to the composition container used for dependency injection.
    /// </summary>
    /// <seealso cref="PDS.Framework.IContainer" />
    public class Container : IContainer
    {
        private CompositionContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        internal Container(CompositionContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Satisfies all registered dependencies for the specified object instance.
        /// </summary>
        /// <param name="instance">The object instance.</param>
        public void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }

        /// <summary>
        /// Registers the specified instance for dependency injection.
        /// </summary>
        /// <typeparam name="T">The contract type.</typeparam>
        /// <param name="instance">The object instance.</param>
        public void Register<T>(T instance)
        {
            _container.ComposeExportedValue<T>(instance);
        }

        /// <summary>
        /// Resolves a single instance of the specified type and optional contract name.
        /// </summary>
        /// <typeparam name="T">The contract type.</typeparam>
        /// <param name="contractName">The contract name.</param>
        /// <returns>The object instance with all dependencies resolved.</returns>
        /// <exception cref="ContainerException">Error resolving contract type or contract name</exception>
        public T Resolve<T>(string contractName = null)
        {
            try
            {
                return _container.GetExportedValue<T>(contractName);
            }
            catch (Exception ex)
            {
                throw new ContainerException("Error resolving type: " + typeof(T).FullName + " and contract name: \"" + contractName + "\"", ex);
            }
        }

        /// <summary>
        /// Resolves a single instance of the specified type and optional contract name.
        /// </summary>
        /// <param name="type">The contract type.</param>
        /// <param name="contractName">The contract name.</param>
        /// <returns>The object instance with all dependencies resolved.</returns>
        public object Resolve(Type type, string contractName = null)
        {
            return ResolveAll(type, contractName)
                .FirstOrDefault();
        }

        /// <summary>
        /// Resolves all instances of the specified type and optional contract name.
        /// </summary>
        /// <typeparam name="T">The contract type.</typeparam>
        /// <param name="contractName">The contract name.</param>
        /// <returns>A collection of object instances with all dependencies resolved.</returns>
        /// <exception cref="ContainerException">Error resolving contract type or contract name</exception>
        public IEnumerable<T> ResolveAll<T>(string contractName = null)
        {
            try
            {
                return _container.GetExportedValues<T>(contractName);
            }
            catch (Exception ex)
            {
                throw new ContainerException("Error resolving all of type: " + typeof(T).FullName + " and contract name: \"" + contractName + "\"", ex);
            }
        }

        /// <summary>
        /// Resolves all instances of the specified type and optional contract name.
        /// </summary>
        /// <param name="type">The contract type.</param>
        /// <param name="contractName">The contract name.</param>
        /// <returns>A collection of object instances with all dependencies resolved.</returns>
        /// <exception cref="ContainerException">Error resolving contract type or contract name</exception>
        public IEnumerable<object> ResolveAll(Type type, string contractName = null)
        {
            if (type == null && string.IsNullOrWhiteSpace(contractName))
                return Enumerable.Empty<object>();

            try
            {
                return _container.GetExports(type, null, contractName)
                    .Select(x => x.Value);
            }
            catch (Exception ex)
            {
                throw new ContainerException("Error resolving all of type: " + type.FullName + " and contract name: " + (contractName ?? "(none)"), ex);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_container != null)
            {
                _container.Dispose();
            }
        }
    }
}
