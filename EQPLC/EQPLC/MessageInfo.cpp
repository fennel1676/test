#include <stdafx.h>
#include "MessageInfo.h"

#include "./MessageInfo/MsgDateTimeCommand.h"
#include "./MessageInfo/MsgEquipmentCommand.h"
#include "./MessageInfo/MsgFlowRecipeControlCommand.h"
#include "./MessageInfo/MsgFlowGroupControlCommand.h"
#include "./MessageInfo/MsgProcessCommand.h"
#include "./MessageInfo/MsgPanelIDInfo.h"
#include "./MessageInfo/MsgOnlineModeCommand.h"
#include "./MessageInfo/MsgCassetteInfoCommand.h"
#include "./MessageInfo/MsgMessageCommand.h"
#include "./MessageInfo/MsgEQConstantCommand.h"
#include "./MessageInfo/MsgAlarmResetCommand.h"
#include "./MessageInfo/MsgPortStartCommand.h"
#include "./MessageInfo/MsgLimitWIPQTYCommand.h"
#include "./MessageInfo/MsgPCDataCommand.h"






using namespace Message;

IMessageInfo* IMessageInfo::CreateInfo(int nCommand)
{
	IMessageInfo* pInfo = NULL;
	switch(nCommand)
	{
	case 1:		pInfo = new CMsgDateTimeCommand;			break;
	case 2:     pInfo = new CMsgEquipmentCommand;           break;
	case 3:		pInfo = new CMsgFlowRecipeControlCommand;	break;
	case 4:		pInfo = new CMsgFlowGroupControlCommand;	break;
	case 10:	pInfo = new CMsgEQConstantCommand;			break;
	case 11:	pInfo = new CMsgMessageCommand;				break;
	case 12:	pInfo = new CMsgAlarmResetCommand;			break;
	case 13:    pInfo = new CMSgOnlineModeCommand;          break;
	case 14:    pInfo = new CMsgProcessCommand;             break;
	case 15:    pInfo = new CMsgCassetteInfoCommand;        break;
	case 16:    pInfo = new CMsgPanelIDInfo;                break;
	case 17:    pInfo = new CMsgLimitWIPQTYCommand;         break;
    case 21:    pInfo = new CMsgPCDataCommand;         break;
	//case 17:    pInfo = new CMsgPortStartCommand;           break;
	}
	return pInfo;
}