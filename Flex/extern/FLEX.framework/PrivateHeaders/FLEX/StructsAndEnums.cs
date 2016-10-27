using System;
using ObjCRuntime;

[Native]
public enum FLEXArgumentInputViewSize : nuint
{
	Default = 0,
	Small,
	Large
}

[Native]
public enum FLEXObjectExplorerSection : nuint
{
	Description,
	Custom,
	Properties,
	Ivars,
	Methods,
	ClassMethods,
	Superclasses,
	ReferencingInstances
}

[Native]
public enum FLEXNetworkTransactionState : nint
{
	Unstarted,
	AwaitingResponse,
	ReceivingData,
	Finished,
	Failed
}
