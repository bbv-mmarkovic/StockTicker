﻿//-------------------------------------------------------------------------------
// <copyright file="StockTickerViewModel.cs" company="bbv Software Services AG">
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
    using System;
    using System.Collections.Generic;

    using Caliburn.Micro;

    using StockTicker.Actions;
    using StockTicker.Externals;
    using StockTicker.FindStocks;
    using StockTicker.ManageStocks;

    internal sealed class StockTickerViewModel : Conductor<IStockTickerContentViewModel>, IStockTickerViewModel
    {
        public StockTickerViewModel(ISearchViewModel searchViewModel, IBusyIndicationViewModel busyIndication)
        {
            this.Search = searchViewModel;
            this.BusyIndication = busyIndication;

            this.DisplayName = General.StockTickerTitle;
        }

        public Func<IActionBuilder> Actions { private get; set; }

        public IBusyIndicationViewModel BusyIndication { get; private set; }

        public ISearchViewModel Search { get; private set; }

        public IEnumerable<IResult> Display(StockSearchModel searched)
        {
            var detailModel = new Future<StockDetailModel>();

            return this.Actions()
                .WithBusyIndication(
                    busyScope => busyScope
                        .GetDetails(searched, detailModel)
                        .ConductContent(detailModel, this),
                    General.DisplayStockDetails);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Coroutine.BeginExecute(this.Actions().ConductDefaultContent(this).GetEnumerator());
        }
    }
}
