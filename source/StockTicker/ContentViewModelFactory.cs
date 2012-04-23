//-------------------------------------------------------------------------------
// <copyright file="ContentViewModelFactory.cs" company="bbv Software Services AG">
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

namespace StockTicker
{
    using Ninject.Syntax;

    using StockTicker.Extensions;
    using StockTicker.Externals;
    using StockTicker.ManageStocks;

    internal class ContentViewModelFactory : IContentViewModelFactory
    {
        private readonly IResolutionRoot resolutionRoot;

        public ContentViewModelFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        public IStockTickerContentViewModel CreateContent(StockDetailModel detailModel)
        {
            return this.resolutionRoot.Get<IStockDetailViewModel>(new { detailModel });
        }
    }
}