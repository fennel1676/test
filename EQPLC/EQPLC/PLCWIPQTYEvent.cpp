#include "StdAfx.h"
#include "PLCWIPQTYEvent.h"

using namespace PLC;

CPLCWIPQTYEvent::CPLCWIPQTYEvent(void)
{
	memset(&stWIPQTY,0x00, sizeof(stWIPQTY));
}

CPLCWIPQTYEvent::~CPLCWIPQTYEvent(void)
{
}

void CPLCWIPQTYEvent::SetData(const char *szTagName, char *pData)
{
	int nIndex = 0;

	//	WIPQTY1PLC1
	memcpy(&stWIPQTY.nWIPQTY1PLC1, &pData[nIndex], 2);
	nIndex += 2;

	//	WIPQTY1PLC2
	memcpy(&stWIPQTY.nWIPQTY1PLC2, &pData[nIndex], 2);
	nIndex += 2;

	//	WIPQTY2PLC1
	memcpy(&stWIPQTY.nWIPQTY2PLC1, &pData[nIndex], 2);
	nIndex += 2;

	//	WIPQTY2PLC2
	memcpy(&stWIPQTY.nWIPQTY2PLC2, &pData[nIndex], 2);
	nIndex += 2;
	IPLC::pPLCEvent->EventWIPQTY(GetPLCNo(), stWIPQTY);
}