﻿//-------------------------------------------------------------------------------
// <copyright file="ExternalsModule.cs" company="bbv Software Services AG">
//   Copyright (c) 2012
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace StockTicker.Externals
{
    using System;

    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    public class ExternalsModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                x.FromThisAssembly()
                .IncludingNonePublicTypes()
                .SelectAllClasses()
                .InNamespaceOf<ExternalsModule>()
                .Where(t => t.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase))
                .BindToDefaultInterface()
                .Configure(c => c.InSingletonScope()));
        }
    }
}