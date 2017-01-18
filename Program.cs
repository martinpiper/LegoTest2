using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LegoDeviceSDK.Generic;
using LegoDeviceSDK.Interfaces;

namespace LegoTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Foo foo = new Foo();
			foo.DoStuff();

			Thread.Sleep(10000);
			Console.WriteLine("Num devices = " + foo.devices.Count);
		}
	}

	public class Foo : IDeviceManagerDelegate
	{
		public List<IDevice> devices = new List<IDevice>();

		public async void DoStuff()
		{
			DeviceManager.SharedDeviceManager.AddDelegate(this);
			await DeviceManager.SharedDeviceManager.ScanAsync();
		}

		public void DeviceDidAppear(IDeviceManager deviceManager2, IDevice device)
		{
			devices.Add(device);
			Console.WriteLine("async Num devices = " + devices.Count);
			Console.WriteLine(device.Name);
		}

		public void DeviceDidDisappear(LegoDeviceSDK.Interfaces.IDeviceManager deviceManager2, LegoDeviceSDK.Interfaces.IDevice device)
		{
		}

		public void DidDisconnectFromDevice(LegoDeviceSDK.Interfaces.IDeviceManager deviceManager2, LegoDeviceSDK.Interfaces.IDevice device, bool foo)
		{
		}

		public void DidFailToConnectToDevice(LegoDeviceSDK.Interfaces.IDeviceManager deviceManager2, LegoDeviceSDK.Interfaces.IDevice device, bool foo)
		{
		}

		public void DidFinishInterrogatingDevice(LegoDeviceSDK.Interfaces.IDeviceManager deviceManager2, LegoDeviceSDK.Interfaces.IDevice device)
		{
		}

		public void DidStartInterrogatingDevice(LegoDeviceSDK.Interfaces.IDeviceManager deviceManager2, LegoDeviceSDK.Interfaces.IDevice device)
		{
		}

		public void WillStartConnectingToDevice(LegoDeviceSDK.Interfaces.IDeviceManager deviceManager2, LegoDeviceSDK.Interfaces.IDevice device)
		{
		}
	}
}
