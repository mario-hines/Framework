﻿using System;
using Framework.Extensions;
using Framework.Interfaces;

namespace Framework.IoC
{
	/// <summary>Manager for generic inversion of control.</summary>
	/// <remarks>Wrapper for managing other injection frameworks.</remarks>
	public class GenericIocManager
	{
		/// <summary>Gets or sets the injector.</summary>
		/// <value>The injector.</value>
		internal static IDependencyInjector Injector { get; private set; }

		/// <summary>Gets a value indicating whether this object is in use.</summary>
		/// <value>true if this object is in use, false if not.</value>
		public static bool IsInUse { get { return !Injector.IsNull(); } }

		/// <summary>Sets the bindings.</summary>
		/// <param name="bind">The bind.</param>
		/// <param name="injector">The injector.</param>
		public static void SetBindings(Func<IDependencyInjector, IDependencyInjector> bind, IDependencyInjector injector) {
			Injector = bind(injector);
		}

		/// <summary>Gets the binding of type.</summary>
		/// <typeparam name="TBinding">Type of the binding.</typeparam>
		/// <param name="parameters">The parameters that may be necessary to retrieve the binding.</param>
		/// <returns>The binding of type&lt; t binding&gt;</returns>
		public static TBinding GetBindingOfType<TBinding>(params IDependencyParameter[] parameters) {
			return Injector.GetBinding<TBinding>(parameters);
		}

		/// <summary>Gets a binding of type.</summary>
		/// <param name="binding">The binding.</param>
		/// <param name="parameters">The parameters that may be necessary to retrieve the binding.</param>
		/// <returns>The binding of type.</returns>
		public static object GetBindingOfType(Type binding, params IDependencyParameter[] parameters) {
			return Injector.GetBinding(binding, parameters);
		}
	}
}