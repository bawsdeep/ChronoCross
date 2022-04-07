using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoCross
{
	internal class ViewModel
	{
		public uint Money
		{
			get => SaveData.Instance().ReadNumber(0x58C, 4);
			set => Util.WriteNumber(0x58C, 4, value, 0, 9999999);
		}

		public uint FileIndex
		{
			get => SaveData.Instance().Adventure;
			set
			{
				SaveData.Instance().UpdateCheckSum();
				SaveData.Instance().Adventure = value;
			}
		}
	}
}
