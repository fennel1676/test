#pragma once


#include "IPLC.h"

namespace PLC
{
class CPLCSignalEvent : public IPLC
{
public:
	CPLCSignalEvent(void);
	virtual ~CPLCSignalEvent(void);

public:
	virtual void SetData(const char *szTagName, char *pData);

private:
	char m_arraySignalBit[32];
public:
	static BOOL m_bPanelSigBit[4];
};
}
