using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using ClassCore;

namespace ProdPlanManager
{
	public class Sheet
	{
		public static void SetFixSize(FarPoint.Win.Spread.FpSpread fp)
		{
			float height = 0.0f;
			float width = 0.0f;

			for (int i = 0; i < fp.Sheets[0].RowCount; i++)
			{
				if (fp.Sheets[0].Rows[i].Visible == true)
					height += fp.Sheets[0].Rows[i].Height;
			}
			for (int i = 0; i < fp.Sheets[0].ColumnHeaderRowCount; i++)
			{
				if (fp.Sheets[0].ColumnHeader.Rows[i].Visible == true)
					height += fp.Sheets[0].ColumnHeader.Rows[i].Height;
			}

			for (int i = 0; i < fp.Sheets[0].ColumnCount; i++)
			{
				if (fp.Sheets[0].Columns[i].Visible == true)
					width += fp.Sheets[0].Columns[i].Width;
			}
			for (int i = 0; i < fp.Sheets[0].RowHeaderColumnCount; i++)
			{
				if (fp.Sheets[0].RowHeader.Columns[i].Visible == true)
					width += fp.Sheets[0].RowHeader.Columns[i].Width;
			}

			fp.Height = (int)height + 4;
			fp.Width = (int)width + 4;
		}
		public static int GetHeight(FarPoint.Win.Spread.FpSpread fp)
		{
			float height = 0.0f;
		
			for (int i = 0; i < fp.Sheets[0].RowCount; i++)
			{
				if (fp.Sheets[0].Rows[i].Visible == true)
					height += fp.Sheets[0].Rows[i].Height;
			}
			for (int i = 0; i < fp.Sheets[0].ColumnHeaderRowCount; i++)
			{
				if (fp.Sheets[0].ColumnHeader.Rows[i].Visible == true)
					height += fp.Sheets[0].ColumnHeader.Rows[i].Height;
			}

			return (int)height;
		}
		public static int GetWidth(FarPoint.Win.Spread.FpSpread fp)
		{
			float width = 0.0f;

			for (int i = 0; i < fp.Sheets[0].ColumnCount; i++)
			{
				if (fp.Sheets[0].Columns[i].Visible == true)
					width += fp.Sheets[0].Columns[i].Width;
			}
			for (int i = 0; i < fp.Sheets[0].RowHeaderColumnCount; i++)
			{
				if (fp.Sheets[0].RowHeader.Columns[i].Visible == true)
					width += fp.Sheets[0].RowHeader.Columns[i].Width;
			}

			return (int)width;
		}
	}

	public class Network
	{
		public static bool IsIP(string ip)
		{
			if (string.IsNullOrEmpty(ip)) return false;

			int d = 0;
			int n = 0;
			int p = 0;
			for (int i = 0; i < ip.Length; i += 1)
			{
				if (ip[i] >= '0' && ip[i] <= '9')
				{
					d += 1;
					if (d > 3)
					{
						return false;
					}
					p *= 10;
					p += ip[i] - '0';
				}
				else if (ip[i] == '.' && d >= 1 && d <= 3)
				{
					d = 0;
					if (p < 0 || p > 255)
					{
						return false;
					}
					n += 1;
					p = 0;
				}
				else
				{
					return false;
				}
			}
			if (n != 3) return false;

			return true;
		}
	}

	public class TimeManager
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct SystemTime
		{
			[MarshalAs(UnmanagedType.U2)]
			public short Year;
			[MarshalAs(UnmanagedType.U2)]
			public short Month;
			[MarshalAs(UnmanagedType.U2)]
			public short DayOfWeek;
			[MarshalAs(UnmanagedType.U2)]
			public short Day;
			[MarshalAs(UnmanagedType.U2)]
			public short Hour;
			[MarshalAs(UnmanagedType.U2)]
			public short Minute;
			[MarshalAs(UnmanagedType.U2)]
			public short Second;
			[MarshalAs(UnmanagedType.U2)]
			public short Milliseconds;
		}

		[DllImport("kernel32.dll")]
		public static extern bool GetLocalTime(ref SystemTime time);
		[DllImport("kernel32.dll")]
		public static extern bool SetLocalTime(ref SystemTime time);

		public static bool SetTime(short year, short month, short day, short hour, short minutes, short second)
		{
			SystemTime time = new SystemTime();
			GetLocalTime(ref time);
			time.Year = year;
			time.Month = month;
			time.Day = day;
			time.Hour = hour;
			time.Minute = minutes;
			time.Second = second;

			return SetLocalTime(ref time);
		}
	}


}


/*FpSpread 코딩순서*/
//Docking
//ActiveSkin
//Split 설정
//스크롤바 설정
//TrackPolicy
//TextTipPolicy
//커서 설정
//Border
//BackColor
//ReadOnly
//HeaderCount
//BodyCount
//Font
//HeaderMerge
//BodyMerge
//Alignment
//Width
//HeaderText
//Lock
//FrozenCount
//CellType
//Visible


/*데이타 변환 및 전송과정*/
//1.지역변수
//2.LCData
//3.Host
//4.EqPLC
//5.Sql
//6.UI
//7.Log
//Host메세지나 Eq메세지 속에서는 자기타입의 메세지를 가장 늦게 전송


/*주석*/
//Host전송부분
//EqPLC전송부분
//DB&UI처리


/*메세지*/
//8ZCIS51_VY51_SN01의 Glass(HJ8FJ107)가 파기되었습니다.
//8ZCIS51_VY51_SN01의 Glass(HJ8FJ107)가 복구되었습니다.
//8ZCIS51_VY51_SN01의 Glass(HJ8FJ107)가 투입되었습니다.
//8ZCIS51_VY51_SN01의 Glass(HJ8FJ107)가 배출되었습니다.
//8ZCIS51_VY51_SN01의 EquipmentState값이 Normal상태로 변경되었습니다.
//8ZCIS51_VY51_SN01의 ProcessState값이 Pause상태로 변경되었습니다.
//8ZCIS51_VY51의 ProcessState값이 Init상태로 3분동안 지속되었습니다.
//8ZCIS51_VY51_SN01_D101에서 [Roller Inverter] 알람이 발생하였습니다.
//8ZCIS51_VY51_SN01_D101에서 [Roller Inverter] 알람이 해제되었습니다.
//8ZCIS51_VY51_SN01_D101에서 PanelidReadFail 이벤트가 발생되었습니다.
//8ZCIS51_VY51_SN01_D101에서 HSValidCheckFail(RT) 이벤트가 발생되었습니다.
