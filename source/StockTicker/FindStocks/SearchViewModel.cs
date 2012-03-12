﻿//-------------------------------------------------------------------------------
// <copyright file="SearchViewModel.cs" company="bbv Software Services AG">
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

namespace StockTicker.FindStocks
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    using Caliburn.Micro;

    using StockTicker.Actions;
    using StockTicker.Externals;

    internal class SearchViewModel : Screen, ISearchViewModel
    {
        public SearchViewModel()
        {
            this.FoundStocks = new BindableCollection<StockSearchModel>();
            this.FoundStocks.CollectionChanged += this.HandleFoundStocksChanged;
        }

        public Func<IActionBuilder> Actions { private get; set; }

        public BindableCollection<StockSearchModel> FoundStocks { get; private set; }

        public bool HasStocks
        {
            get
            {
                return this.FoundStocks.Any();
            }
        }

        public IEnumerable<IResult> FindStocks(string searchPattern)
        {
            return this.Actions().Search(searchPattern, this.FoundStocks);
        }

        private void HandleFoundStocksChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.NotifyOfPropertyChange(() => this.HasStocks);
        }
    }
}