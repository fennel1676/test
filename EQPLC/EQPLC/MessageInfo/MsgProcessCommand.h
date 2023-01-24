#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgProcessCommand : public IMessageInfo
	{
	public:
		CMsgProcessCommand(void);
		virtual ~CMsgProcessCommand(void);

	public:
		virtual const CString GetMsg() { return _T(""); }
		virtual bool ParseMsg(const CString& strXML);

	public:
		int nPortNo;
		int nCommandID;
		CString strCassetteID;
		int nMapStif;
		int nStartStif;
		int nByWho;
	};
}