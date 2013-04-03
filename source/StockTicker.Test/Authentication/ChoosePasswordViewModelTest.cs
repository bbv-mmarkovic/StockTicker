﻿//-------------------------------------------------------------------------------
// <copyright file="ChoosePasswordViewModelTest.cs" company="bbv Software Services AG">
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

namespace StockTicker.Authentication
{
    using System.Security;

    using FluentAssertions;

    using FluentValidation;

    using Moq;

    using Xunit;

    public class ChoosePasswordViewModelTest
    {
        private readonly Mock<IValidatorFactory> validatorFactory;

        private readonly ChoosePasswordViewModel testee;

        public ChoosePasswordViewModelTest()
        {
            this.validatorFactory = new Mock<IValidatorFactory>();

            this.testee = new ChoosePasswordViewModel(this.validatorFactory.Object);
        }

        [Fact]
        public void Password_ShouldRaisePropertyChanged()
        {
            this.testee.MonitorEvents();

            this.testee.Password = new SecureString();

            this.testee.ShouldRaisePropertyChangeFor(t => t.Password);
            this.testee.ShouldRaisePropertyChangeFor(t => t.PasswordRetype);
        }

        [Fact]
        public void PasswordRetype_ShouldRaisePropertyChanged()
        {
            this.testee.MonitorEvents();

            this.testee.PasswordRetype = new SecureString();

            this.testee.ShouldRaisePropertyChangeFor(t => t.PasswordRetype);
            this.testee.ShouldRaisePropertyChangeFor(t => t.Password);
        }
    }
}