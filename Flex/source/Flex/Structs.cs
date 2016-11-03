using System;
using ObjCRuntime;

namespace Flex
{
	[Native]
	public enum FLEXArgumentInputViewSize : long
	{
		Default = 0,
		Small,
		Large
	}

[	Native]
	public enum FLEXObjectExplorerSection : uint
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
	public enum FLEXNetworkTransactionState : long
	{
		Unstarted,
		AwaitingResponse,
		ReceivingData,
		Finished,
		Failed
	}
}