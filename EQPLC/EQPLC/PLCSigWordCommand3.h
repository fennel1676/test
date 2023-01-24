#pragma once

#include "IPLC.h"

namespace PLC
{
class CPLCSigWordCommand3 : public IPLC
{
public:
	struct ECID_INFO
	{
		short nECID;
		short nECDEF;
		short nECSLL;
		short nECSUL;
		short nECWLL;
		short nECWUL;
	};

public:
	CPLCSigWordCommand3(void);
	virtual ~CPLCSigWordCommand3(void);

public:
	virtual void GetData(char * szOutData);
	void SetECIDCmd(short nCommandID, ECID_INFO *pstECIDCmd);

private:
	void MakeECIDCmd(int &nIndex);

private:
	char m_szData[248];

	short m_nCommandID;
	ECID_INFO m_stECIDCmd[15];
};
}