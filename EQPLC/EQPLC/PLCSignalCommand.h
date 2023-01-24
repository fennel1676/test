#pragma once

#include "IPLC.h"

namespace PLC
{
class CPLCSignalCommand : public IPLC
{
public:
	CPLCSignalCommand(void);
	virtual ~CPLCSignalCommand(void);

public:
	virtual void GetData(char *pData)
	{
		memcpy(pData, m_arraySignalBit, sizeof(m_arraySignalBit));
	}

	void EventSignalPLCAlive();  
	void EventSignalDatetimeSet(BOOL bSet);
	void EventSignalEquipmentCmd(BOOL bSet);
	void EventSignalProcessPort1Cmd(BOOL bSet);
	void EventSignalProcessPort2Cmd(BOOL bSet);
	void EventSignalProcessPort3Cmd(BOOL bSet);
	void EventSignalProcessPort4Cmd(BOOL bSet);
	void EventOnlineModeCmd(BOOL bSet);

	void EventSignalOPCallCmd(BOOL bSet);
	void EventSignalFlowCtrlCmd(BOOL bSet);

	void EventSignalPanelID1ReqEvt(BOOL bSet);
	void EventSignalPanelID2ReqEvt(BOOL bSet);
	void EventSignalPanelID3ReqEvt(BOOL bSet);
	void EventSignalPanelID4ReqEvt(BOOL bSet);

	void EventSignalEQConstantCmd(BOOL bSet);

	void EventSignalPortStart1(BOOL bSet);
	void EventSignalPortStart2(BOOL bSet);


	void EventSignalTerminalMsgCmd(BOOL bSet);
	void EventSignalFlowRecipe(BOOL bSet);

	void EventSignalPort1(BOOL bSet);
	void EventSignalPort2(BOOL bSet);
	void EventSignalPort3(BOOL bSet);
	void EventSignalPort4(BOOL bSet);

	void EventSignalUnitReport(int nUnitNo, BOOL bSet);
	void EventSignalUnitCtrlCmd(int nUnitNo, BOOL bSet);

	void EventSignalPort1Duplication(BOOL bSet);
	void EventSignalPort2Duplication(BOOL bSet);
	void EventSignalPort3Duplication(BOOL bSet);
	void EventSignalPort4Duplication(BOOL bSet);

	void EventSignalPCData1(BOOL bSet);
	void EventSignalPCData2(BOOL bSet);
	void EventSignalPCData3(BOOL bSet);
	void EventSignalPCData4(BOOL bSet);

	void EventSignalPLCData1(BOOL bSet);	
	void EventSignalPLCData2(BOOL bSet);
	void EventSignalPLCData3(BOOL bSet);
	void EventSignalPLCData4(BOOL bSet);

	void EventSignalAutoCommand(BOOL bSet);

	void EventSignalPort1InitReqEvt(BOOL bSet);
	void EventSignalPort2InitReqEvt(BOOL bSet);
	void EventSignalPort3InitReqEvt(BOOL bSet);
	void EventSignalPort4InitReqEvt(BOOL bSet);

private:
	char m_arraySignalBit[32];
public:
	BOOL m_bCheck;
};
}