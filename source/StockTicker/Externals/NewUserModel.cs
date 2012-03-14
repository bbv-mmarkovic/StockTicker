//-------------------------------------------------------------------------------
// <copyright file="NewUserModel.cs" company="bbv Software Services AG">
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
    using System.Security;

    internal class NewUserModel
    {
        public NewUserModel(string firstName, string lastName, string username, SecureString password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Password = password;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; private set; }

        public SecureString Password { get; private set; }
    }
}