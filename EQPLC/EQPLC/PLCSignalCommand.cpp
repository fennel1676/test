#include "StdAfx.h"
#include "PLCSignalCommand.h"
#include "ABConfig.h"

using namespace PLC;

//BOOL CPLCSignalCommand::m_bCheck;

CPLCSignalCommand::CPLCSignalCommand(void)
{
	memset(m_arraySignalBit, 0x00, sizeof(m_arraySignalBit));
	m_bCheck = TRUE;
}

CPLCSignalCommand::~CPLCSignalCommand(void)
{
}

void CPLCSignalCommand::EventSignalPLCAlive()
{
	char cBuf = m_arraySignalBit[0] & 0x01;
	if(0 == cBuf)
	{
		m_arraySignalBit[0] |= 0x01;
	}
	else			
	{
		m_arraySignalBit[0] &= 0xFE;
	}
}

void CPLCSignalCommand::EventSignalDatetimeSet(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[0] |= 0x02;
	else		m_arraySignalBit[0] &= 0xFD;
}

void CPLCSignalCommand::EventSignalEquipmentCmd(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[0] |= 0x04;
	else		m_arraySignalBit[0] &= 0xFB;
}

void CPLCSignalCommand::EventSignalProcessPort1Cmd(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[0] |= 0x08;
	else		m_arraySignalBit[0] &= 0xF7;
}

void CPLCSignalCommand::EventSignalProcessPort2Cmd(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[0] |= 0x10;
	else		m_arraySignalBit[0] &= 0xEF;
}

void CPLCSignalCommand::EventSignalProcessPort3Cmd(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[0] |= 0x20;
	else		m_arraySignalBit[0] &= 0xDF;
}

void CPLCSignalCommand::EventSignalProcessPort4Cmd(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[0] |= 0x40;
	else		m_arraySignalBit[0] &= 0xBF;
}

void CPLCSignalCommand::EventOnlineModeCmd(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[0] |= 0x80;
	else		m_arraySignalBit[0] &= 0x7F;
}

void CPLCSignalCommand::EventSignalTerminalMsgCmd(BOOL bSet)
{
	if(bSet)	
	{
		m_arraySignalBit[1] |= 0x01;
		CABConfig::g_bTerminalSignal = TRUE;
	}
	else
	{
		m_arraySignalBit[1] &= 0xFE;
		CABConfig::g_bTerminalSignal = FALSE;
	}
}

void CPLCSignalCommand::EventSignalOPCallCmd(BOOL bSet)
{
	if(bSet)
	{
		m_arraySignalBit[1] |= 0x02;
		CABConfig::g_bOPCallSignal = TRUE;
	}
	else
	{
		m_arraySignalBit[1] &= 0xFD;
		CABConfig::g_bOPCallSignal = FALSE;
	}
}

void CPLCSignalCommand::EventSignalFlowCtrlCmd(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[1] |= 0x04;
	else		m_arraySignalBit[1] &= 0xFB;
}

void CPLCSignalCommand::EventSignalPanelID1ReqEvt(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[1] |= 0x08;
	else		m_arraySignalBit[1] &= 0xF7;
}

void CPLCSignalCommand::EventSignalPanelID2ReqEvt(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[1] |= 0x10;
	else		m_arraySignalBit[1] &= 0xEF;
}

void CPLCSignalCommand::EventSignalPanelID3ReqEvt(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[1] |= 0x20;
	else		m_arraySignalBit[1] &= 0xDF;
}

void CPLCSignalCommand::EventSignalPanelID4ReqEvt(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[1] |= 0x40;
	else		m_arraySignalBit[1] &= 0x3F;
}

void CPLCSignalCommand::EventSignalEQConstantCmd(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[1] |= 0x80;
	else		m_arraySignalBit[1] &= 0x7F;
}

void CPLCSignalCommand::EventSignalPortStart1(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[2] |= 0x01;
	else		m_arraySignalBit[2] &= 0xFE;
}

void CPLCSignalCommand::EventSignalPortStart2(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[2] |= 0x02;
	else		m_arraySignalBit[2] &= 0xFD;
}


void CPLCSignalCommand::EventSignalPort1(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[2] |= 0x04;
	else		m_arraySignalBit[2] &= 0xFB;
}

void CPLCSignalCommand::EventSignalPort2(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[2] |= 0x08;
	else		m_arraySignalBit[2] &= 0xF7;
}

void CPLCSignalCommand::EventSignalPort3(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[2] |= 0x10;
	else		m_arraySignalBit[2] &= 0xEF;
}

void CPLCSignalCommand::EventSignalPort4(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[2] |= 0x20;
	else		m_arraySignalBit[2] &= 0xDF;
}

void CPLCSignalCommand::EventSignalFlowRecipe(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[2] |= 0x80;
	else		m_arraySignalBit[2] &= 0x7F;
}

void CPLCSignalCommand::EventSignalPort1Duplication(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[3] |= 0x01;
	else		m_arraySignalBit[3] &= 0xFE;
}

void CPLCSignalCommand::EventSignalPort2Duplication(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[3] |= 0x02;
	else		m_arraySignalBit[3] &= 0xFD;
}

void CPLCSignalCommand::EventSignalPort3Duplication(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[3] |= 0x04;
	else		m_arraySignalBit[3] &= 0xFB;
}

void CPLCSignalCommand::EventSignalPort4Duplication(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[3] |= 0x08;
	else		m_arraySignalBit[3] &= 0xF7;
}

void CPLCSignalCommand::EventSignalPCData1(BOOL bSet)
{
	if(bSet)
		m_arraySignalBit[3] |= 0x10;
	else
		m_arraySignalBit[3] &= 0xEF;
}

void CPLCSignalCommand::EventSignalPCData2(BOOL bSet)
{
	if(bSet)
		m_arraySignalBit[3] |= 0x20;
	else
		m_arraySignalBit[3] &= 0xDF;
}

void CPLCSignalCommand::EventSignalPCData3(BOOL bSet)
{
	if(bSet)
		m_arraySignalBit[3] |= 0x40;
	else
		m_arraySignalBit[3] &= 0xBF;
}

void CPLCSignalCommand::EventSignalPCData4(BOOL bSet)
{
	if(bSet)
		m_arraySignalBit[3] |= 0x80;
	else
		m_arraySignalBit[3] &= 0x7F;
}
//void CPLCSignalCommand::EventSignalAutoCommand(BOOL bSet)
//{
//	if(bSet)	m_arraySignalBit[3] |= 0x80;
//	else		m_arraySignalBit[3] &= 0x7F;
//}

void CPLCSignalCommand::EventSignalPLCData1(BOOL bSet)
{
	if(bSet)
		m_arraySignalBit[4] |= 0x10;
	else
		m_arraySignalBit[4] &= 0xEF;
}

void CPLCSignalCommand::EventSignalPLCData2(BOOL bSet)
{
	if(bSet)
		m_arraySignalBit[4] |= 0x20;
	else
		m_arraySignalBit[4] &= 0xDF;
}

void CPLCSignalCommand::EventSignalPLCData3(BOOL bSet)
{
	if(bSet)
		m_arraySignalBit[4] |= 0x40;
	else
		m_arraySignalBit[4] &= 0xBF;
}

void CPLCSignalCommand::EventSignalPLCData4(BOOL bSet)
{
	if(bSet)
		m_arraySignalBit[4] |= 0x80;
	else
		m_arraySignalBit[4] &= 0x7F;
}



void CPLCSignalCommand::EventSignalPort1InitReqEvt(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[31] |= 0x10;
	else		m_arraySignalBit[31] &= 0xEF;
}

void CPLCSignalCommand::EventSignalPort2InitReqEvt(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[31] |= 0x20;
	else		m_arraySignalBit[31] &= 0xDF;
}

void CPLCSignalCommand::EventSignalPort3InitReqEvt(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[31] |= 0x40;
	else		m_arraySignalBit[31] &= 0x3F;
}

void CPLCSignalCommand::EventSignalPort4InitReqEvt(BOOL bSet)
{
	if(bSet)	m_arraySignalBit[31] |= 0x80;
	else		m_arraySignalBit[31] &= 0x7F;
}

void CPLCSignalCommand::EventSignalUnitReport(int nUnitNo, BOOL bSet)
{
	int nIndex = nUnitNo / 8;
	int nUnitIndex = nUnitNo % 8;

	switch(nUnitIndex)
	{
	case 0:
		if(m_bCheck == TRUE && nIndex == 0)
		{
			if(bSet)	
				m_arraySignalBit[4 + nIndex] |= 0x01;
			else		
				m_arraySignalBit[4 + nIndex] &= 0xFE;
		}
		return;
	case 1:
		if(m_bCheck == TRUE && nIndex == 0)
		{
			if(bSet)	
				m_arraySignalBit[4 + nIndex] |= 0x02;
			else
				m_arraySignalBit[4 + nIndex] &= 0xFD;
		}
		return;
	case 2:	
		if(m_bCheck == TRUE && nIndex == 0)
		{
			if(bSet)	
				m_arraySignalBit[4 + nIndex] |= 0x04;
					
			else		
				m_arraySignalBit[4 + nIndex] &= 0xFB;
		}
		return;
	case 3:	
		if(m_bCheck == TRUE && nIndex == 0)
		{
			if(bSet)	
				m_arraySignalBit[4 + nIndex] |= 0x08;
			else
				m_arraySignalBit[4 + nIndex] &= 0xF7;
		}
		return;
	case 4:	
		if(bSet)	
			m_arraySignalBit[4 + nIndex] |= 0x10;
		else		
			m_arraySignalBit[4 + nIndex] &= 0xEF;
		return;
	case 5:		
		if(bSet)	
			m_arraySignalBit[4 + nIndex] |= 0x20;
		else		
			m_arraySignalBit[4 + nIndex] &= 0xDF;
		return;
	case 6:		
		if(bSet)	
			m_arraySignalBit[4 + nIndex] |= 0x40;
		else		
			m_arraySignalBit[4 + nIndex] &= 0xBF;
		return;
	case 7:		
		if(bSet)	
			m_arraySignalBit[4 + nIndex] |= 0x80;
		else	
			m_arraySignalBit[4 + nIndex] &= 0x7F;
		return;
	}
}

void CPLCSignalCommand::EventSignalUnitCtrlCmd(int nUnitNo, BOOL bSet)
{
	int nIndex = nUnitNo / 8;
	int nUnitIndex = nUnitNo % 8;

	switch(nUnitIndex)
	{
	case 0:		if(bSet)	m_arraySignalBit[16 + nIndex] |= 0x01;
				else		m_arraySignalBit[16 + nIndex] &= 0xFE;
				return;
	case 1:		if(bSet)	m_arraySignalBit[16 + nIndex] |= 0x02;
				else		m_arraySignalBit[16 + nIndex] &= 0xFD;
				return;
	case 2:		if(bSet)	m_arraySignalBit[16 + nIndex] |= 0x04;
				else		m_arraySignalBit[16 + nIndex] &= 0xFB;
				return;
	case 3:		if(bSet)	m_arraySignalBit[16 + nIndex] |= 0x08;
				else		m_arraySignalBit[16 + nIndex] &= 0xF7;
				return;
	case 4:		if(bSet)	m_arraySignalBit[16 + nIndex] |= 0x10;
				else		m_arraySignalBit[16 + nIndex] &= 0xEF;
				return;
	case 5:		if(bSet)	m_arraySignalBit[16 + nIndex] |= 0x20;
				else		m_arraySignalBit[16 + nIndex] &= 0xDF;
				return;
	case 6:		if(bSet)	m_arraySignalBit[16 + nIndex] |= 0x40;
				else		m_arraySignalBit[16 + nIndex] &= 0xBF;
				return;
	case 7:		if(bSet)	m_arraySignalBit[16 + nIndex] |= 0x80;
				else		m_arraySignalBit[16 + nIndex] &= 0x7F;
				return;
	}
}

