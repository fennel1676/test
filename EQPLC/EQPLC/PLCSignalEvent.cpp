#include "StdAfx.h"
#include "PLCSignalEvent.h"
#include "ABConfig.h"

using namespace PLC;
BOOL CPLCSignalEvent::m_bPanelSigBit[4];

CPLCSignalEvent::CPLCSignalEvent(void)
{
	memset(m_arraySignalBit, 0x00, sizeof(m_arraySignalBit));
}

CPLCSignalEvent::~CPLCSignalEvent(void)
{
}

void CPLCSignalEvent::SetData(const char *szTagName, char *pData)
{
	const byte nIndex[8] = {0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80};  //1byte표시
	int i = 0, j = 0;
	BOOL bSend = FALSE, bSet = FALSE;

	//	1 Byte
	i = 0;
	if(m_arraySignalBit[i] != pData[i])  // 데이터가 0이 아니라면!
	{
		bSend = TRUE;
		//	CCS_Alive
		if(((m_arraySignalBit[i] & nIndex[0]) != (pData[i] & nIndex[0])))
		{
			bSet = ((pData[i] & nIndex[0]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPLCAlive(GetPLCNo(), bSet);
		}
		//	DatetimeSetReply
		if((m_arraySignalBit[i] & nIndex[1]) != (pData[i] & nIndex[1]))
		{
			bSet = ((pData[i] & nIndex[1]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalDatetimeSet(GetPLCNo(), bSet);
		}
		//	EquipmentCtrlReply
		if((m_arraySignalBit[i] & nIndex[2]) != (pData[i] & nIndex[2]))
		{
			bSet = ((pData[i] & nIndex[2]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalEquipmentCmd(GetPLCNo(), bSet);
		}

		//	ProcessPort1CmdReply
		if((m_arraySignalBit[i] & nIndex[3]) != (pData[i] & nIndex[3]))
		{
			bSet = ((pData[i] & nIndex[3]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalProcessPort1Cmd(GetPLCNo(), bSet);
		}
		//	ProcessPort2CmdReply
		if((m_arraySignalBit[i] & nIndex[4]) != (pData[i] & nIndex[4]))
		{
			bSet = ((pData[i] & nIndex[4]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalProcessPort2Cmd(GetPLCNo(), bSet);
		}
		//	ProcessPort3CmdReply
		if((m_arraySignalBit[i] & nIndex[5]) != (pData[i] & nIndex[5]))
		{
			bSet = ((pData[i] & nIndex[5]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalProcessPort3Cmd(GetPLCNo(), bSet);
		}
		//	ProcessPort4CmdReply
		if((m_arraySignalBit[i] & nIndex[6]) != (pData[i] & nIndex[6]))
		{
			bSet = ((pData[i] & nIndex[6]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalProcessPort4Cmd(GetPLCNo(), bSet);
		}
	}

	//	2 Byte
	i++;
	if(m_arraySignalBit[i] != pData[i])
	{
		bSend = TRUE;
		//	TerminalCmd
		if((m_arraySignalBit[i] & nIndex[0]) != (pData[i] & nIndex[0]))
		{
			bSet = ((pData[i] & nIndex[0]) == 0) ? FALSE : TRUE;
			CABConfig::g_bTerminalSignal_PLC = bSet;
			IPLC::pPLCEvent->EventSignalTerminalMsgCmd(GetPLCNo(), bSet);
		}

		//	OpCallCmd
		if((m_arraySignalBit[i] & nIndex[1]) != (pData[i] & nIndex[1]))
		{
			bSet = ((pData[i] & nIndex[1]) == 0) ? FALSE : TRUE;
			CABConfig::g_bOPCallSignal_PLC = bSet;
			IPLC::pPLCEvent->EventSignalOPCallCmd(GetPLCNo(), bSet);
		}

		//	FlowCtrlReply
		if(0 != (pData[i] & nIndex[2]) && ((m_arraySignalBit[i] & nIndex[2]) != (pData[i] & nIndex[2])))
			IPLC::pPLCEvent->EventSignalFlowCtrlCmd(GetPLCNo());

		// PanelID1ReqEvt
		if((m_arraySignalBit[i] & nIndex[3]) != (pData[i] & nIndex[3]))
		{
			bSet = ((pData[i] & nIndex[3]) == 0) ? FALSE : TRUE;
			CPLCSignalEvent::m_bPanelSigBit[0] = bSet;
			IPLC::pPLCEvent->EventSignalPanelID1ReqEvt(GetPLCNo(), bSet);
		}

		// PanelID2ReqEvt
		if((m_arraySignalBit[i] & nIndex[4]) != (pData[i] & nIndex[4]))
		{
			bSet = ((pData[i] & nIndex[4]) == 0) ? FALSE : TRUE;
			CPLCSignalEvent::m_bPanelSigBit[1] = bSet;
			IPLC::pPLCEvent->EventSignalPanelID2ReqEvt(GetPLCNo(), bSet);
		}

		// PanelID3ReqEvt
		if((m_arraySignalBit[i] & nIndex[5]) != (pData[i] & nIndex[5]))
		{
			bSet = ((pData[i] & nIndex[5]) == 0) ? FALSE : TRUE;
			CPLCSignalEvent::m_bPanelSigBit[2] = bSet;
			IPLC::pPLCEvent->EventSignalPanelID3ReqEvt(GetPLCNo(), bSet);
		}

		// PanelID4ReqEvt
		if((m_arraySignalBit[i] & nIndex[6]) != (pData[i] & nIndex[6]))
		{
			bSet = ((pData[i] & nIndex[6]) == 0) ? FALSE : TRUE;
			CPLCSignalEvent::m_bPanelSigBit[3] = bSet;
			IPLC::pPLCEvent->EventSignalPanelID4ReqEvt(GetPLCNo(), bSet);
		}

		//	EQ ConstantReply
		if(0 != (pData[i] & nIndex[7]) && ((m_arraySignalBit[i] & nIndex[7]) != (pData[i] & nIndex[7])))
			IPLC::pPLCEvent->ECInfoCmdReply(GetPLCNo());

	}
	//	3 Byte
	i++;
	if(m_arraySignalBit[i] != pData[i])
	{
		bSend = TRUE;
		// Port1Evt
		if((m_arraySignalBit[i] & nIndex[2]) != (pData[i] & nIndex[2]))
		{
			bSet = ((pData[i] & nIndex[2]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort1(GetPLCNo(), bSet);
		}
		// Port2Evt
		if((m_arraySignalBit[i] & nIndex[3]) != (pData[i] & nIndex[3]))
		{
			bSet = ((pData[i] & nIndex[3]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort2(GetPLCNo(), bSet);
		}
		// Port3Evt
		if((m_arraySignalBit[i] & nIndex[4]) != (pData[i] & nIndex[4]))
		{
			bSet = ((pData[i] & nIndex[4]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort3(GetPLCNo(), bSet);
		}
		// Port4Evt
		if((m_arraySignalBit[i] & nIndex[5]) != (pData[i] & nIndex[5]))
		{
			bSet = ((pData[i] & nIndex[5]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort4(GetPLCNo(), bSet);
		}

		//	FlowRecipeEvt
		if((m_arraySignalBit[i] & nIndex[7]) != (pData[i] & nIndex[7]))
		{
			bSet = ((pData[i] & nIndex[7]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalFlowRecipe(GetPLCNo(), bSet);
		}		
	}
	//	4 Byte
	i++;
	if(m_arraySignalBit[i] != pData[i])
	{
		bSend = TRUE;
		// Port1DupEvt
		if((m_arraySignalBit[i] & nIndex[0]) != (pData[i] & nIndex[0]))
		{
			bSet = ((pData[i] & nIndex[0]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort1Duplication(GetPLCNo(), bSet);
		}

		// Port2DupEvt
		if((m_arraySignalBit[i] & nIndex[1]) != (pData[i] & nIndex[1]))
		{
			bSet = ((pData[i] & nIndex[1]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort2Duplication(GetPLCNo(), bSet);
		}

		// Port3DupEvt
		if((m_arraySignalBit[i] & nIndex[2]) != (pData[i] & nIndex[2]))
		{
			bSet = ((pData[i] & nIndex[2]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort3Duplication(GetPLCNo(), bSet);
		}

		// Port4DupEvt
		if((m_arraySignalBit[i] & nIndex[3]) != (pData[i] & nIndex[3]))
		{
			bSet = ((pData[i] & nIndex[3]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort4Duplication(GetPLCNo(), bSet);
		}
		
		//	PCData1
		if((m_arraySignalBit[i] & nIndex[4]) != (pData[i] & nIndex[4]))
		{
			bSet = ((pData[i] & nIndex[4]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPCData1Cmd(GetPLCNo(), bSet);
		}
		//	PCData2
		if((m_arraySignalBit[i] & nIndex[5]) != (pData[i] & nIndex[5]))
		{
			bSet = ((pData[i] & nIndex[5]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPCData2Cmd(GetPLCNo(), bSet);
		}
		//	PCData3
		if((m_arraySignalBit[i] & nIndex[6]) != (pData[i] & nIndex[6]))
		{
			bSet = ((pData[i] & nIndex[6]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPCData3Cmd(GetPLCNo(), bSet);
		}
		//	PCData4
		if((m_arraySignalBit[i] & nIndex[7]) != (pData[i] & nIndex[7]))
		{
			bSet = ((pData[i] & nIndex[7]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPCData4Cmd(GetPLCNo(), bSet);
		}
	}


	//	5 Byte
	i++;
	// PLCData1
	if((m_arraySignalBit[i] & nIndex[4]) != (pData[i] & nIndex[4]))
	{
		bSet = ((pData[i] & nIndex[4]) == 0) ? FALSE : TRUE;
		IPLC::pPLCEvent->EventSignalPLCData1(GetPLCNo(), bSet);
	}
	// PLCData1
	if((m_arraySignalBit[i] & nIndex[5]) != (pData[i] & nIndex[5]))
	{
		bSet = ((pData[i] & nIndex[5]) == 0) ? FALSE : TRUE;
		IPLC::pPLCEvent->EventSignalPLCData2(GetPLCNo(), bSet);
	}
	// PLCData1
	if((m_arraySignalBit[i] & nIndex[6]) != (pData[i] & nIndex[6]))
	{
		bSet = ((pData[i] & nIndex[6]) == 0) ? FALSE : TRUE;
		IPLC::pPLCEvent->EventSignalPLCData3(GetPLCNo(), bSet);
	}
	// PLCData1
	if((m_arraySignalBit[i] & nIndex[7]) != (pData[i] & nIndex[7]))
	{
		bSet = ((pData[i] & nIndex[7]) == 0) ? FALSE : TRUE;
		IPLC::pPLCEvent->EventSignalPLCData4(GetPLCNo(), bSet);
	}
	int k = 0;
	for(k = 0; k < 12; k++)
	{
		if(m_arraySignalBit[i + k] != pData[i + k])
		{
			bSend = TRUE;
			for(int j = 0; j < 8; j++)
			{
				if((m_arraySignalBit[i + k] & nIndex[j]) != (pData[i + k] & nIndex[j]))
				{
					bSet = ((pData[i + k] & nIndex[j]) == 0) ? FALSE : TRUE;
					IPLC::pPLCEvent->EventSignalUnitReport(GetPLCNo(), k * 8 + j, bSet);
				}
			}
		}
	}
	i += k+1;

	//	18 Byte
	for(k = 0; k < 12; k++)
	{
		if(m_arraySignalBit[i + k] != pData[i + k])
		{
			bSend = TRUE;
			for(int j = 0; j < 8; j++)
			{
				if(0 != (pData[i + k] & nIndex[j]) && ((m_arraySignalBit[i + k] & nIndex[j]) != (pData[i + k] & nIndex[j])))
					IPLC::pPLCEvent->EventSignalUnitCtrlCmd(GetPLCNo(), k * 8 + j);
			}
		}
	}
	i = 31;

	// 32Byte
	if(m_arraySignalBit[i] != pData[i])
	{
		bSend = TRUE;
		// Port1Pause
		if((m_arraySignalBit[i] & nIndex[0]) != (pData[i] & nIndex[0]))
		{
			bSet = ((pData[i] & nIndex[0]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort1State(GetPLCNo(), bSet);
		}

		// Port2Pause
		if((m_arraySignalBit[i] & nIndex[1]) != (pData[i] & nIndex[1]))
		{
			bSet = ((pData[i] & nIndex[1]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort2State(GetPLCNo(), bSet);
		}

		// Port3Pause
		if((m_arraySignalBit[i] & nIndex[2]) != (pData[i] & nIndex[2]))
		{
			bSet = ((pData[i] & nIndex[2]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort3State(GetPLCNo(), bSet);
		}

		// Port4Pause
		if((m_arraySignalBit[i] & nIndex[3]) != (pData[i] & nIndex[3]))
		{
			bSet = ((pData[i] & nIndex[3]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort4State(GetPLCNo(), bSet);
		}
		
		// Port1InitReq
		if((m_arraySignalBit[i] & nIndex[4]) != (pData[i] & nIndex[4]))
		{
			bSet = ((pData[i] & nIndex[4]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort1InitReq(GetPLCNo(), bSet);
		}

		// Port2InitReq
		if((m_arraySignalBit[i] & nIndex[5]) != (pData[i] & nIndex[5]))
		{
			bSet = ((pData[i] & nIndex[5]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort2InitReq(GetPLCNo(), bSet);
		}

		// Port3InitReq
		if((m_arraySignalBit[i] & nIndex[6]) != (pData[i] & nIndex[6]))
		{
			bSet = ((pData[i] & nIndex[6]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort3InitReq(GetPLCNo(), bSet);
		}

		// Port4InitReq
		if((m_arraySignalBit[i] & nIndex[7]) != (pData[i] & nIndex[7]))
		{
			bSet = ((pData[i] & nIndex[7]) == 0) ? FALSE : TRUE;
			IPLC::pPLCEvent->EventSignalPort4InitReq(GetPLCNo(), bSet);
		}
	}


	memcpy(m_arraySignalBit, pData, sizeof(m_arraySignalBit));

	if(bSend)
		IPLC::pPLCEvent->EventSignalBitDataSend(GetPLCNo());
}