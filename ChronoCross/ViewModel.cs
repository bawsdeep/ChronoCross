using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoCross
{
	internal class ViewModel
	{
		public List<String> FileNameList { get; private set; } = new List<String>();
		public ViewModel()
		{
			// Shift_JIS
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			for (uint index = 0; index < 15; index++)
			{
				if (!String.IsNullOrEmpty(SaveData.Instance().ReadTextDirect((index + 1) * 0x2000, 2)))
				{
					var filename = SaveData.Instance().ReadTextDirect((index + 1) * 0x2000 + 4, 0x40);
					FileNameList.Add(filename);
				}
			}
		}

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
