#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgPanelIDInfo : public IMessageInfo
	{
	public:
		CMsgPanelIDInfo(void);
		virtual ~CMsgPanelIDInfo(void);

	public:
		virtual const CString GetMsg() { return _T(""); }
		virtual bool ParseMsg(const CString& strXML);

	public:
		int nPortNo;
		CString strHPanelID;
		CString strUniqueID;
		int nUniqueID[4];
	};
}