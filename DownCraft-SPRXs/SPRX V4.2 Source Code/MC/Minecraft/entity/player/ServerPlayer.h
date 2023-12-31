#pragma once

#include "Player.h"
#include "../../inventory/IContainerListener.h"

// Size : 3480
class ServerPlayer : public Player, public IContainerListener
{
public:
	//void **vtable;		// 3444
	char filler1[20];		// 3448
	int containerCount;		// 3468
	char filler2[8];		// 3472

public:
	ServerPlayer(Level &, PacketSender &, bool, const uint32_t &, void*); // Level &, PacketSender &, bool, const RakNet::RakNetGUID &, std::function<void(ServerPlayer &)>
	virtual ~ServerPlayer();
	virtual void normalTick();
	virtual void knockback(Entity *, int, float, float);
	virtual void aiStep();
	virtual void hurtArmor(int);
	virtual void onEffectAdded(MobEffectInstance&);
	virtual void onEffectUpdated(MobEffectInstance const&);
	virtual void onEffectRemoved(MobEffectInstance &);
	virtual void tickWorld(const Tick &);
	virtual void hasResource(int);
	virtual void openContainer(ChestTileEntity *);
	virtual void openFurnace(FurnaceTileEntity *);
	virtual void displayChatMessage(const std::string &, const std::string &);
	virtual void displayClientMessage(const wchar_t*);
	virtual void displayLocalizableMessage(const std::string &, const std::vector<std::string> &);
	virtual void stopSleepInBed(bool, bool);
	virtual void closeContainer();
	virtual void setContainerData(BaseContainerMenu *, int, int);
	virtual void slotChanged(BaseContainerMenu *, int, const ItemInstance &, bool);
	virtual void refreshContainer(BaseContainerMenu *, const std::vector<ItemInstance> &);
	void disconnect();
	void doCloseContainer();
	void nextContainerCounter();
	void setPlayerInput(float, float, bool, bool);
};
