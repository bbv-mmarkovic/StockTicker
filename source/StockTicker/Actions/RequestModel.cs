//-------------------------------------------------------------------------------
// <copyright file="RequestModel.cs" company="bbv Software Services AG">
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

namespace StockTicker.Actions
{
    using System;

    internal class RequestModel : IEquatable<RequestModel>
    {
        public RequestModel(Guid requestId)
            : this(requestId, null)
        {
        }

        public RequestModel(Guid requestId, string message)
        {
            this.RequestId = requestId;
            this.Message = message;
        }

        public Guid RequestId { get; private set; }

        public string Message { get; private set; }

        public bool Equals(RequestModel other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return other.RequestId.Equals(this.RequestId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(RequestModel))
            {
                return false;
            }

            return this.Equals((RequestModel)obj);
        }

        public override int GetHashCode()
        {
            return this.RequestId.GetHashCode();
        }
    }
}