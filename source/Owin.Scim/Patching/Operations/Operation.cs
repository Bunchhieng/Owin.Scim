// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Owin.Scim.Patching.Operations
{
    using System;

    using Newtonsoft.Json;

    public class Operation : OperationBase
    {
        [JsonProperty("value")]
        public object value { get; set; }

        public Operation()
        {

        }

        public Operation(string op, string path, object value)
            : base(op, path)
        {
            this.value = value;
        }

        public Operation(string op, string path)
            : base(op, path)
        {
        }

        public void Apply(object objectToApplyTo, IObjectAdapter adapter)
        {
            if (objectToApplyTo == null)
            {
                throw new ArgumentNullException(nameof(objectToApplyTo));
            }

            if (adapter == null)
            {
                throw new ArgumentNullException(nameof(adapter));
            }

            switch (OperationType)
            {
                case OperationType.Add:
                    adapter.Add(this, objectToApplyTo);
                    break;
                case OperationType.Remove:
                    adapter.Remove(this, objectToApplyTo);
                    break;
                case OperationType.Replace:
                    adapter.Replace(this, objectToApplyTo);
                    break;
            }
        }

        public bool ShouldSerializevalue()
        {
            return (OperationType == OperationType.Add || OperationType == OperationType.Replace);
        }
    }
}