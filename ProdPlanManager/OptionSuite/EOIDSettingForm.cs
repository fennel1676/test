using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassCore;

namespace T8_1_CCS
{
	public partial class EOIDSettingForm : Form
	{
		public EOIDSettingForm()
		{
			InitializeComponent();
		}
		private void EOIDSettingForm_Load(object sender, EventArgs e)
		{
			//ActiveSkin
			FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpread1);

			//스크롤바 설정
			fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;

			//TextTipPolicy
			fpSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;

			//커서 설정
			fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Arrow);
			fpSpread1.SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Arrow);

			//HeaderCount
			fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
			fpSpread1_Sheet1.ColumnHeader.RowCount = 1;

			//BodyCount
			fpSpread1_Sheet1.RowCount = 20;
			fpSpread1_Sheet1.ColumnCount = 3;

			//Font
			fpSpread1.Font = new Font("Arial", 8.25f);
			for (int i = 0; i < fpSpread1_Sheet1.RowHeader.ColumnCount; i++)
				fpSpread1_Sheet1.RowHeader.Columns[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);
			for (int i = 0; i < fpSpread1_Sheet1.ColumnHeader.RowCount; i++)
				fpSpread1_Sheet1.ColumnHeader.Rows[i].Font = new Font("Arial", 8.25f, FontStyle.Bold);

			//Alignment
			for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
			{
				fpSpread1_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
				fpSpread1_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			}

			//Width
			fpSpread1_Sheet1.Columns[0].Width = 160.0f;
			fpSpread1_Sheet1.Columns[1].Width = 120.0f;
			fpSpread1_Sheet1.Columns[2].Width = 120.0f;
			for (int i = 0; i < fpSpread1_Sheet1.ColumnCount; i++)
				fpSpread1_Sheet1.Columns[i].Resizable = false;

			//HeaderText
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 0].Text = "EOID";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 1].Text = "EOMD";
			fpSpread1_Sheet1.ColumnHeader.Cells[0, 2].Text = "EOV";

			//Lock
			fpSpread1_Sheet1.Columns[0].Locked = true;
			fpSpread1_Sheet1.Columns[1].Locked = true;

			//Body
			fpSpread1_Sheet1.Cells[0, 0].RowSpan = 2;
			fpSpread1_Sheet1.Cells[4, 0].RowSpan = 6;
			fpSpread1_Sheet1.Cells[10, 0].RowSpan = 5;
			fpSpread1_Sheet1.Cells[15, 0].RowSpan = 5;
			fpSpread1_Sheet1.Cells[0, 0].Text = "Component Trace";
			fpSpread1_Sheet1.Cells[2, 0].Text = "Equipment State Trace";
			fpSpread1_Sheet1.Cells[3, 0].Text = "Process State Trace";
			fpSpread1_Sheet1.Cells[4, 0].Text = "Process State Lapse Time";
			fpSpread1_Sheet1.Cells[10, 0].Text = "VCR Reading Mode";
			fpSpread1_Sheet1.Cells[15, 0].Text = "Wait time for GlassID";

			fpSpread1_Sheet1.Cells[0, 1].Text = "Panel Process Start";
			fpSpread1_Sheet1.Cells[1, 1].Text = "Panel Process End";
			fpSpread1_Sheet1.Cells[2, 1].Text = "Don't Care";
			fpSpread1_Sheet1.Cells[3, 1].Text = "Don't Care";
			fpSpread1_Sheet1.Cells[4, 1].Text = "INIT";
			fpSpread1_Sheet1.Cells[5, 1].Text = "IDLE";
			fpSpread1_Sheet1.Cells[6, 1].Text = "SETUP";
			fpSpread1_Sheet1.Cells[7, 1].Text = "READY";
			fpSpread1_Sheet1.Cells[8, 1].Text = "EXECUTE";
			fpSpread1_Sheet1.Cells[9, 1].Text = "PAUSE";
			fpSpread1_Sheet1.Cells[10, 1].Text = "VCR 1";
			fpSpread1_Sheet1.Cells[11, 1].Text = "VCR 2";
			fpSpread1_Sheet1.Cells[12, 1].Text = "VCR 3";
			fpSpread1_Sheet1.Cells[13, 1].Text = "VCR 4";
			fpSpread1_Sheet1.Cells[14, 1].Text = "VCR 5";
			fpSpread1_Sheet1.Cells[15, 1].Text = "VCR 1";
			fpSpread1_Sheet1.Cells[16, 1].Text = "VCR 2";
			fpSpread1_Sheet1.Cells[17, 1].Text = "VCR 3";
			fpSpread1_Sheet1.Cells[18, 1].Text = "VCR 4";
			fpSpread1_Sheet1.Cells[19, 1].Text = "VCR 5";

			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			comboType1.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
			comboType1.Items = new String[] { "Equipment level", "1st module level" };
			comboType1.ItemData = new string[] { "1", "2" };

			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			comboType2.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
			comboType2.Items = new String[] { "OFF", "Equipment level", "1st module level" };
			comboType2.ItemData = new string[] { "0", "1", "2" };

			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			comboType3.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
			comboType3.MaxDrop = 15;
			comboType3.Items = new String[] { "Time off", "1 minute", "2 minute", "3 minute", "4 minute", "5 minute", "6 minute", "7 minute", "8 minute", "9 minute", "10 minute",
												"11 minute", "12 minute", "13 minute", "14 minute", "15 minute", "16 minute", "17 minute", "18 minute", "19 minute", "20 minute",
												"21 minute", "22 minute", "23 minute", "24 minute", "25 minute", "26 minute", "27 minute", "28 minute", "29 minute", "30 minute",
												"31 minute", "32 minute", "33 minute", "34 minute", "35 minute", "36 minute", "37 minute", "38 minute", "39 minute", "40 minute",
												"41 minute", "42 minute", "43 minute", "44 minute", "45 minute", "46 minute", "47 minute", "48 minute", "49 minute", "50 minute",
												"51 minute", "52 minute", "53 minute", "54 minute", "55 minute", "56 minute", "57 minute", "58 minute", "59 minute", "60 minute",
												"61 minute", "62 minute", "63 minute", "64 minute", "65 minute", "66 minute", "67 minute", "68 minute", "69 minute", "70 minute",
												"71 minute", "72 minute", "73 minute", "74 minute", "75 minute", "76 minute", "77 minute", "78 minute", "79 minute", "80 minute",
												"81 minute", "82 minute", "83 minute", "84 minute", "85 minute", "86 minute", "87 minute", "88 minute", "89 minute", "90 minute",
												"91 minute", "92 minute", "93 minute", "94 minute", "95 minute", "96 minute", "97 minute", "98 minute", "99 minute" };
			comboType3.ItemData = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
												"21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40",
												"41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60",
												"61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80",
												"81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"};

			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			comboType4.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
			comboType4.Items = new String[] { "VCR OFF", "VCR ON", "VCR Mismatch ON" };
			comboType4.ItemData = new string[] { "0", "1", "2" };

			FarPoint.Win.Spread.CellType.ComboBoxCellType comboType5 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			comboType5.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
			comboType5.MaxDrop = 15;
			comboType5.Items = new String[] { "OFF", "1 second", "2 second", "3 second", "4 second", "5 second", "6 second", "7 second", "8 second", "9 second", "10 second",
												"11 second", "12 second", "13 second", "14 second", "15 second", "16 second", "17 second", "18 second", "19 second", "20 second",
												"21 second", "22 second", "23 second", "24 second", "25 second", "26 second", "27 second", "28 second", "29 second", "30 second",
												"31 second", "32 second", "33 second", "34 second", "35 second", "36 second", "37 second", "38 second", "39 second", "40 second",
												"41 second", "42 second", "43 second", "44 second", "45 second", "46 second", "47 second", "48 second", "49 second", "50 second",
												"51 second", "52 second", "53 second", "54 second", "55 second", "56 second", "57 second", "58 second", "59 second", "60 second",
												"61 second", "62 second", "63 second", "64 second", "65 second", "66 second", "67 second", "68 second", "69 second", "70 second",
												"71 second", "72 second", "73 second", "74 second", "75 second", "76 second", "77 second", "78 second", "79 second", "80 second",
												"81 second", "82 second", "83 second", "84 second", "85 second", "86 second", "87 second", "88 second", "89 second", "90 second",
												"91 second", "92 second", "93 second", "94 second", "95 second", "96 second", "97 second", "98 second", "99 second", "100 second",
												"101 second", "102 second", "103 second", "104 second", "105 second", "106 second", "107 second", "108 second", "109 second", "110 second",
												"111 second", "112 second", "113 second", "114 second", "115 second", "116 second", "117 second", "118 second", "119 second", "120 second",
												"121 second", "122 second", "123 second", "124 second", "125 second", "126 second", "127 second", "128 second", "129 second", "130 second",
												"131 second", "132 second", "133 second", "134 second", "135 second", "136 second", "137 second", "138 second", "139 second", "140 second",
												"141 second", "142 second", "143 second", "144 second", "145 second", "146 second", "147 second", "148 second", "149 second", "150 second",
												"151 second", "152 second", "153 second", "154 second", "155 second", "156 second", "157 second", "158 second", "159 second", "160 second",
												"161 second", "162 second", "163 second", "164 second", "165 second", "166 second", "167 second", "168 second", "169 second", "170 second",
												"171 second", "172 second", "173 second", "174 second", "175 second", "176 second", "177 second", "178 second", "179 second", "180 second",
												"181 second", "182 second", "183 second", "184 second", "185 second", "186 second", "187 second", "188 second", "189 second", "190 second",
												"191 second", "192 second", "193 second", "194 second", "195 second", "196 second", "197 second", "198 second", "199 second", "200 second",
												"201 second", "202 second", "203 second", "204 second", "205 second", "206 second", "207 second", "208 second", "209 second", "210 second",
												"211 second", "212 second", "213 second", "214 second", "215 second", "216 second", "217 second", "218 second", "219 second", "220 second",
												"221 second", "222 second", "223 second", "224 second", "225 second", "226 second", "227 second", "228 second", "229 second", "230 second",
												"231 second", "232 second", "233 second", "234 second", "235 second", "236 second", "237 second", "238 second", "239 second", "240 second",
												"241 second", "242 second", "243 second", "244 second", "245 second", "246 second", "247 second", "248 second", "249 second", "250 second",
												"251 second", "252 second", "253 second", "254 second", "Wait Infinity" };
			comboType5.ItemData = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
												"21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40",
												"41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60",
												"61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80",
												"81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100",
												"101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120",
												"121", "122", "123", "124", "125", "126", "127", "128", "129", "130", "131", "132", "133", "134", "135", "136", "137", "138", "139", "140",
												"141", "142", "143", "144", "145", "146", "147", "148", "149", "150", "151", "152", "153", "154", "155", "156", "157", "158", "159", "160",
												"161", "162", "163", "164", "165", "166", "167", "168", "169", "170", "171", "172", "173", "174", "175", "176", "177", "178", "179", "180",
												"181", "182", "183", "184", "185", "186", "187", "188", "189", "190", "191", "192", "193", "194", "195", "196", "197", "198", "199", "200",
												"201", "202", "203", "204", "205", "206", "207", "208", "209", "210", "211", "212", "213", "214", "215", "216", "217", "218", "219", "220",
												"221", "222", "223", "224", "225", "226", "227", "228", "229", "230", "231", "232", "233", "234", "235", "236", "237", "238", "239", "240",
												"241", "242", "243", "244", "245", "246", "247", "248", "249", "250", "251", "252", "253", "254", "255" };

			fpSpread1_Sheet1.Cells[0, 2].CellType = comboType1;
			fpSpread1_Sheet1.Cells[1, 2].CellType = comboType1;
			fpSpread1_Sheet1.Cells[2, 2].CellType = comboType2;
			fpSpread1_Sheet1.Cells[3, 2].CellType = comboType2;
			fpSpread1_Sheet1.Cells[4, 2].CellType = comboType3;
			fpSpread1_Sheet1.Cells[5, 2].CellType = comboType3;
			fpSpread1_Sheet1.Cells[6, 2].CellType = comboType3;
			fpSpread1_Sheet1.Cells[7, 2].CellType = comboType3;
			fpSpread1_Sheet1.Cells[8, 2].CellType = comboType3;
			fpSpread1_Sheet1.Cells[9, 2].CellType = comboType3;
			fpSpread1_Sheet1.Cells[10, 2].CellType = comboType4;
			fpSpread1_Sheet1.Cells[11, 2].CellType = comboType4;
			fpSpread1_Sheet1.Cells[12, 2].CellType = comboType4;
			fpSpread1_Sheet1.Cells[13, 2].CellType = comboType4;
			fpSpread1_Sheet1.Cells[14, 2].CellType = comboType4;
			fpSpread1_Sheet1.Cells[15, 2].CellType = comboType5;
			fpSpread1_Sheet1.Cells[16, 2].CellType = comboType5;
			fpSpread1_Sheet1.Cells[17, 2].CellType = comboType5;
			fpSpread1_Sheet1.Cells[18, 2].CellType = comboType5;
			fpSpread1_Sheet1.Cells[19, 2].CellType = comboType5;

			fpSpread1_Sheet1.Cells[0, 2].Value = LCData.GetEqOnlineParam(1, "1").ToString();
			fpSpread1_Sheet1.Cells[1, 2].Value = LCData.GetEqOnlineParam(1, "2").ToString();
			fpSpread1_Sheet1.Cells[2, 2].Value = LCData.GetEqOnlineParam(2, "0").ToString();
			fpSpread1_Sheet1.Cells[3, 2].Value = LCData.GetEqOnlineParam(3, "0").ToString();
			fpSpread1_Sheet1.Cells[4, 2].Value = LCData.GetEqOnlineParam(4, "1").ToString();
			fpSpread1_Sheet1.Cells[5, 2].Value = LCData.GetEqOnlineParam(4, "2").ToString();
			fpSpread1_Sheet1.Cells[6, 2].Value = LCData.GetEqOnlineParam(4, "3").ToString();
			fpSpread1_Sheet1.Cells[7, 2].Value = LCData.GetEqOnlineParam(4, "4").ToString();
			fpSpread1_Sheet1.Cells[8, 2].Value = LCData.GetEqOnlineParam(4, "5").ToString();
			fpSpread1_Sheet1.Cells[9, 2].Value = LCData.GetEqOnlineParam(4, "6").ToString();
			fpSpread1_Sheet1.Cells[10, 2].Value = LCData.GetEqOnlineParam(15, "1").ToString();
			fpSpread1_Sheet1.Cells[11, 2].Value = LCData.GetEqOnlineParam(15, "2").ToString();
			fpSpread1_Sheet1.Cells[12, 2].Value = LCData.GetEqOnlineParam(15, "3").ToString();
			fpSpread1_Sheet1.Cells[13, 2].Value = LCData.GetEqOnlineParam(15, "4").ToString();
			fpSpread1_Sheet1.Cells[14, 2].Value = LCData.GetEqOnlineParam(15, "5").ToString();
			fpSpread1_Sheet1.Cells[15, 2].Value = LCData.GetEqOnlineParam(16, "1").ToString();
			fpSpread1_Sheet1.Cells[16, 2].Value = LCData.GetEqOnlineParam(16, "2").ToString();
			fpSpread1_Sheet1.Cells[17, 2].Value = LCData.GetEqOnlineParam(16, "3").ToString();
			fpSpread1_Sheet1.Cells[18, 2].Value = LCData.GetEqOnlineParam(16, "4").ToString();
			fpSpread1_Sheet1.Cells[19, 2].Value = LCData.GetEqOnlineParam(16, "5").ToString();

			//Visible
			if (LCData.CCSType != eCCSType.PIXEL1 && LCData.CCSType != eCCSType.DEPO && LCData.CCSType != eCCSType.ETCH1 && LCData.CCSType != eCCSType.ETCH2)
				fpSpread1_Sheet1.Rows[10].Visible = false;
			if (LCData.CCSType != eCCSType.PIXEL1 && LCData.CCSType != eCCSType.DEPO)
				fpSpread1_Sheet1.Rows[11].Visible = false;
			if (LCData.CCSType != eCCSType.PIXEL1)
				fpSpread1_Sheet1.Rows[12].Visible = false;

			fpSpread1_Sheet1.Rows[13].Visible = false;
			fpSpread1_Sheet1.Rows[14].Visible = false;

			if (LCData.CCSType != eCCSType.PIXEL1 && LCData.CCSType != eCCSType.DEPO && LCData.CCSType != eCCSType.ETCH1 && LCData.CCSType != eCCSType.ETCH2)
				fpSpread1_Sheet1.Rows[15].Visible = false;
			if (LCData.CCSType != eCCSType.PIXEL1 && LCData.CCSType != eCCSType.DEPO)
				fpSpread1_Sheet1.Rows[16].Visible = false;
			if (LCData.CCSType != eCCSType.PIXEL1)
				fpSpread1_Sheet1.Rows[17].Visible = false;

			fpSpread1_Sheet1.Rows[18].Visible = false;
			fpSpread1_Sheet1.Rows[19].Visible = false;

			Sheet.SetFixSize(fpSpread1);
			groupBox1.Height = fpSpread1.Height + 30;
			btnOK.Top = fpSpread1.Height + 50;
			btnCancel.Top = fpSpread1.Height + 50;
			this.Height = fpSpread1.Height + 120;
		}

		private short EOVParse(object value)
		{
			short result;

			try
			{
				result = short.Parse(value.ToString());
			}
			catch
			{
				result = -1;
			}

			return result;
		}

		private void fpSpread1_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
		{
			if (e.Column == 0) fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column + 1);
			else fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column - 1);
			fpSpread1_Sheet1.SetActiveCell(e.Row, e.Column);
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			//Password입력
			PasswordInputForm passwordInputForm = new PasswordInputForm();
			DialogResult passwordResult = passwordInputForm.ShowDialog();
			if (passwordResult != DialogResult.OK) return;

			short eo1_1 = EOVParse(fpSpread1_Sheet1.Cells[0, 2].Value);
			short eo1_2 = EOVParse(fpSpread1_Sheet1.Cells[1, 2].Value);
			short eo2_0 = EOVParse(fpSpread1_Sheet1.Cells[2, 2].Value);
			short eo3_0 = EOVParse(fpSpread1_Sheet1.Cells[3, 2].Value);
			short eo4_1 = EOVParse(fpSpread1_Sheet1.Cells[4, 2].Value);
			short eo4_2 = EOVParse(fpSpread1_Sheet1.Cells[5, 2].Value);
			short eo4_3 = EOVParse(fpSpread1_Sheet1.Cells[6, 2].Value);
			short eo4_4 = EOVParse(fpSpread1_Sheet1.Cells[7, 2].Value);
			short eo4_5 = EOVParse(fpSpread1_Sheet1.Cells[8, 2].Value);
			short eo4_6 = EOVParse(fpSpread1_Sheet1.Cells[9, 2].Value);
			short eo15_1 = EOVParse(fpSpread1_Sheet1.Cells[10, 2].Value);
			short eo15_2 = EOVParse(fpSpread1_Sheet1.Cells[11, 2].Value);
			short eo15_3 = EOVParse(fpSpread1_Sheet1.Cells[12, 2].Value);
			short eo15_4 = EOVParse(fpSpread1_Sheet1.Cells[13, 2].Value);
			short eo15_5 = EOVParse(fpSpread1_Sheet1.Cells[14, 2].Value);
			short eo16_1 = EOVParse(fpSpread1_Sheet1.Cells[15, 2].Value);
			short eo16_2 = EOVParse(fpSpread1_Sheet1.Cells[16, 2].Value);
			short eo16_3 = EOVParse(fpSpread1_Sheet1.Cells[17, 2].Value);
			short eo16_4 = EOVParse(fpSpread1_Sheet1.Cells[18, 2].Value);
			short eo16_5 = EOVParse(fpSpread1_Sheet1.Cells[19, 2].Value);
			
			//ChangeEqOnlieParams Add
			LCData.ChangeEqOnlineParams.Clear();
			if (LCData.GetEqOnlineParam(1, "1") != eo1_1) LCData.SetChangeEqOnlineParam(1, "1", eo1_1);
			if (LCData.GetEqOnlineParam(1, "2") != eo1_2) LCData.SetChangeEqOnlineParam(1, "2", eo1_2);
			if (LCData.GetEqOnlineParam(2, "0") != eo2_0) LCData.SetChangeEqOnlineParam(2, "0", eo2_0);
			if (LCData.GetEqOnlineParam(3, "0") != eo3_0) LCData.SetChangeEqOnlineParam(3, "0", eo3_0);
			if (LCData.GetEqOnlineParam(4, "1") != eo4_1) LCData.SetChangeEqOnlineParam(4, "1", eo4_1);
			if (LCData.GetEqOnlineParam(4, "2") != eo4_2) LCData.SetChangeEqOnlineParam(4, "2", eo4_2);
			if (LCData.GetEqOnlineParam(4, "3") != eo4_3) LCData.SetChangeEqOnlineParam(4, "3", eo4_3);
			if (LCData.GetEqOnlineParam(4, "4") != eo4_4) LCData.SetChangeEqOnlineParam(4, "4", eo4_4);
			if (LCData.GetEqOnlineParam(4, "5") != eo4_5) LCData.SetChangeEqOnlineParam(4, "5", eo4_5);
			if (LCData.GetEqOnlineParam(4, "6") != eo4_6) LCData.SetChangeEqOnlineParam(4, "6", eo4_6);
			if (LCData.CCSType == eCCSType.PIXEL1 || LCData.CCSType == eCCSType.DEPO || LCData.CCSType == eCCSType.ETCH1 || LCData.CCSType == eCCSType.ETCH2)
			{
				if (LCData.GetEqOnlineParam(15, "1") != eo15_1) LCData.SetChangeEqOnlineParam(15, "1", eo15_1);
				if (LCData.GetEqOnlineParam(16, "1") != eo16_1) LCData.SetChangeEqOnlineParam(16, "1", eo16_1);
			}
			if (LCData.CCSType == eCCSType.PIXEL1 || LCData.CCSType == eCCSType.DEPO)
			{
				if (LCData.GetEqOnlineParam(15, "2") != eo15_2) LCData.SetChangeEqOnlineParam(15, "2", eo15_2);
				if (LCData.GetEqOnlineParam(16, "2") != eo16_2) LCData.SetChangeEqOnlineParam(16, "2", eo16_2);
			}
			if (LCData.CCSType == eCCSType.PIXEL1)
			{
				if (LCData.GetEqOnlineParam(15, "3") != eo15_3) LCData.SetChangeEqOnlineParam(15, "3", eo15_3);
				if (LCData.GetEqOnlineParam(16, "3") != eo16_3) LCData.SetChangeEqOnlineParam(16, "3", eo16_3);
			}

			//EqOnlieParams Setting
			LCData.SetEqOnlineParam(1, "1", eo1_1);
			LCData.SetEqOnlineParam(1, "2", eo1_2);
			LCData.SetEqOnlineParam(2, "0", eo2_0);
			LCData.SetEqOnlineParam(3, "0", eo3_0);
			LCData.SetEqOnlineParam(4, "1", eo4_1);
			LCData.SetEqOnlineParam(4, "2", eo4_2);
			LCData.SetEqOnlineParam(4, "3", eo4_3);
			LCData.SetEqOnlineParam(4, "4", eo4_4);
			LCData.SetEqOnlineParam(4, "5", eo4_5);
			LCData.SetEqOnlineParam(4, "6", eo4_6);
			if (LCData.CCSType == eCCSType.PIXEL1 || LCData.CCSType == eCCSType.DEPO || LCData.CCSType == eCCSType.ETCH1 || LCData.CCSType == eCCSType.ETCH2)
			{
				LCData.SetEqOnlineParam(15, "1", eo15_1);
				LCData.SetEqOnlineParam(16, "1", eo16_1);
			}
			if (LCData.CCSType == eCCSType.PIXEL1 || LCData.CCSType == eCCSType.DEPO)
			{
				LCData.SetEqOnlineParam(15, "2", eo15_2);
				LCData.SetEqOnlineParam(16, "2", eo16_2);
			}
			if (LCData.CCSType == eCCSType.PIXEL1)
			{
				LCData.SetEqOnlineParam(15, "3", eo15_3);
				LCData.SetEqOnlineParam(16, "3", eo16_3);
			}

			//현CCS에서 사용하는곳 없음
			//LCData.SetEqOnlineParam(15, "4", eo15_4);
			//LCData.SetEqOnlineParam(16, "4", eo16_4);
			//LCData.SetEqOnlineParam(15, "5", eo15_5);
			//LCData.SetEqOnlineParam(16, "5", eo16_5);

			this.DialogResult = DialogResult.OK;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

	}
}
