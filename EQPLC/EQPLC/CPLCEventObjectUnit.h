#pragma once

#include "IPLC.h"
#include "CPLCSigEventObject.h"

namespace PLC
{
	class CPLCEventObjectUnit : public IPLC
	{
	public:
		CPLCEventObjectUnit(void);
		virtual ~CPLCEventObjectUnit(void);

	public:
		virtual void SetData(const char *szTagName, char *pData);
		virtual void SetTagName(CString strTagName);

	private:
		CPLCSigEventObject m_objPLCEventUnit[4];
	public:
		static BOOL m_bInitPort;
		static short m_nInitCount;
	};
}