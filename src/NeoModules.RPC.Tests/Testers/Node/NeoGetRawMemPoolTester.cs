using NeoModules.JsonRpc.Client;
using NeoModules.RPC.Services.Node;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NeoModules.RPC.Tests.Testers.Node
{
	public class NeoGetRawMemPoolTester : RpcRequestTester<string[]>
	{
		[Fact]
		public async void ShouldReturnMemoryPool()
		{
			var result = await ExecuteAsync();
			Assert.NotNull(result);
			if(result != null) Assert.All(result, str => str.StartsWith("0x"));
		}

		public override async Task<string[]> ExecuteAsync(IClient client)
		{
			var memoryPool = new NeoGetRawMemPool(client);
			return await memoryPool.SendRequestAsync();
		}

		public override Type GetRequestType()
		{
			return typeof(string[]);
		}
	}
}
