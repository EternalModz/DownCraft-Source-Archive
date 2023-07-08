
typedef struct Vector2
{
	float x, y;
	Vector2()
	{
		this->x = this->y = 0;
	}

	Vector2(float x, float y)
	{
		this->x = x;
		this->y = y;
	}

	bool operator==(Vector2& Vec)
	{
		return (this->x == Vec.x && this->y == Vec.y);
	}
	const Vector2& operator- (Vector2 const& Vector)
	{
		return Vector2(this->x - Vector.x, this->y - Vector.y);
	}
	const Vector2& operator+ (Vector2 const& Vector)
	{
		return Vector2(this->x + Vector.x, this->y + Vector.y);
	}
}Vector2, * PVector2;

typedef struct Vector3
{
	float x, y, z;
	Vector3()
	{
		x = y = z = 0;
	}
	Vector3(float x, float y, float z)
	{
		this->x = x; this->y = y; this->z = z;
	}
	const Vector3& operator-(void) const {
		return Vector3(-x, -y, -z);
	}
	const bool operator==(const Vector3& v) const {
		return x == v.x && y == v.y && z == v.z;
	}
	const bool operator!=(const Vector3& v) const {
		return !(*this == v);
	}
	const Vector3& operator+(const Vector3& v) const {
		return Vector3(x + v.x, y + v.y, z + v.z);
	}
	const Vector3& operator-(const Vector3& v) const {
		return Vector3(x - v.x, y - v.y, z - v.z);
	}
	const Vector3& operator*(float fl) const {
		return Vector3(x * fl, y * fl, z * fl);
	}
	const Vector3& operator/(float fl) const {
		return Vector3(x / fl, y / fl, z / fl);
	}
	const float Length(void) const {
		return (float)sqrtf(x * x + y * y + z * z);
	}
	float Vector3::getLength() const {
		return sqrtf((x * x) + (y * y) + (z * z));
	}
	const Vector3 Normalize(void) const
	{
		float flLen = Length();
		if (flLen == 0) return Vector3(0, 0, 1); // ????
		flLen = 1 / flLen;
		return Vector3(x * flLen, y * flLen, z * flLen);
	}

	float Distance(Vector3 const& Vector)
	{
		return sqrtf(DistanceEx(Vector));
	}
	float DistanceEx(Vector3 const& Vector)
	{
		float _x = this->x - Vector.x, _y = this->y - Vector.y, _z = this->z - Vector.z;
		return ((_x * _x) + (_y * _y) + (_z * _z));
	}
	float DotProduct(Vector3 const& Vector)
	{
		return (this->x * Vector.x) + (this->y * Vector.y) + (this->z * Vector.z);
	}
	const Vector3& RoundHalfUp()
	{
		return Vector3(floor(this->x + 0.5), floor(this->y + 0.5), floor(this->z + 0.5));
	}\
		const Vector3& RoundHalfDown()
	{
		return Vector3(floor(this->x + 0.5), floor(this->y + 0.5), floor(this->z + 0.5));
	}
} Vector3, * PVector3;

namespace myMath {
#define PI (3.1415926535897931)
	float abs(float a) {
		if (a < 0)
			return a * -1;
		return a;
	}
	float DegreesToRadians(float Degrees)
	{
		return Degrees * PI / 180.0f;
	}

	float RadiansToDegrees(float Radians)
	{
		return Radians * 180.0f / PI;
	}

	float sin(float deg) {
		bool neg = false;
		while (deg >= 360) deg = deg - 360;
		while (deg < 0) deg = deg + 360;
		if (deg > 180) {
			deg = deg - 180;
			neg = true;
		}
		float ret = (float)(4 * deg * (180 - deg)) / (40500 - (deg * (180 - deg)));
		if (neg)return ret * -1;
		return ret;
	}

	float cos(float AnglesDeg)
	{
		float AnglesRad = DegreesToRadians(AnglesDeg);
		float Rad = (float)(PI / 2.0f) - AnglesRad;
		float ang = RadiansToDegrees(Rad);
		return sin(ang);
	}

	double atan(double x, int n)
	{
		double a = 0.0;// 1st term
		double sum = 0.0;

		// special cases
		if (x == 1.0) return PI / 4.0;
		if (x == -1.0) return -PI / 4.0;

		if (n > 0)
		{
			if ((x < -1.0) || (x > 1.0))
			{
				// constant term
				if (x > 1.0)
					sum = PI / 2.0;
				else
					sum = -PI / 2.0;
				// initial value of a
				a = -1.0 / x;
				for (int j = 1; j <= n; j++)
				{
					sum += a;
					a *= -1.0 * (2.0 * j - 1) / ((2.0 * j + 1) * x * x);// next term from last
				}
			}
			else// -1 < x < 1
			{
				// constant term
				sum = 0.0;
				// initial value of a
				a = x;
				for (int j = 1; j <= n; j++)
				{
					sum += a;
					a *= -1.0 * (2.0 * j - 1) * x * x / (2.0 * j + 1);// next term from last
				}
			}
			//r_err = a;// max. error = 1st term not taken for alternating series
		}

		return sum;
	}

	double atan2(double y, double x)
	{
		double u = atan(y / x, 24);
		if (x < 0.0)// 2nd, 3rd quadrant
		{
			if (u > 0.0)// will go to 3rd quadrant
				u -= PI;
			else
				u += PI;
		}
		return u;
	}
}

struct rgb {
	int r;
	int g;
	int b;
};
long color(int r, int g, int b)
{
	return 0xFF000000 + ((r & 0xff) << 16) + ((g & 0xff) << 8) + (b & 0xff);
}
int _colorX[3];
int* colorInt(int r, int g, int b)
{
	_colorX[0] = r;
	_colorX[1] = g;
	_colorX[2] = b;
	return _colorX;
}
long color(int* rgb_)
{
	return 0xFF000000 + ((rgb_[0] & 0xff) << 16) + ((rgb_[1] & 0xff) << 8) + (rgb_[2] & 0xff);
}

struct font_t {
	char __padd000[0x0004];
	const wchar_t* text;
	int dataType;
	char __padd001[0x0008];
	int wcstrlen;
	int wcstrlen1;
	char __padd002[0x0008];
	float unknown1;
	float unknown2;
	float unknown3;
	float unknown4;
};


class Timer {
public:

};

class LevelRenderer {
public:

	virtual void LevelRenderer_Destructor(); //index 0
	virtual void LevelRenderer_Destructor_0(); //index 1
	virtual void func_14C0B50(); //index 2
	virtual void func_14C0B58(); //index 3
	virtual void func_14C0B60(); //index 4
	virtual void func_14C0B48(); //index 5
	virtual void func_14C0B68(); //index 6
	virtual void nullsub_0(); //index 7
	virtual void nullsub_1(); //index 8
	virtual void func_14C0B78(); //index 9
	virtual void func_14C0B80(); //index 10
	virtual void func_14C0B88(); //index 11
	virtual void func_14C0B90(); //index 12
	virtual void nullsub_2(); //index 13
	virtual void func_14C0B98(); //index 14
	virtual void func_14C0BA0(); //index 15
	virtual void func_14C0BA8(); //index 16
	virtual void nullsub_3(); //index 17


	char __padding000[0x19C];
	float location[3];

};

class DataFixerUpper { //need to reverse
public:

};

class ItemEntity { //need to reverse
public:

};

class Entity { //need to reverse
public:

};
class MultiPlayerGameMode {
public:

};







class LivingEntity { //need to reverse
public:

};

class AxisAlignedBB { //need to reverse
public:

};

class ModifiableAttributeMap {
public:

};



class MultiPlayerLevel {
public:

	int seaLevel;
	char __padding000[0x0010];
	int hash_magic;
	char __padding001[0x0008];
	uint32_t EntityList;
	uint32_t mobEntityList;

	virtual void func_14C0830(); //index 0
	virtual void func_14C0838(); //index 1
	virtual void func_14A1AC8(); //index 2
	virtual void func_14A1988(); //index 3
	virtual void func_14A1980(); //index 4
	virtual void func_14A1990(); //index 5
	virtual void func_14A1998(); //index 6
	virtual void func_14A19A0(); //index 7
	virtual void func_14A19A8(); //index 8
	virtual void func_14A19B0(); //index 9
	virtual void func_14A19B8(); //index 10
	virtual void func_14A19F0(); //index 11
	virtual void func_14A19C0(); //index 12
	virtual void func_14A19C8(); //index 13
	virtual void func_14A1A20(); //index 14
	virtual void func_14A19D0(); //index 15
	virtual void func_14A19D8(); //index 16
	virtual void func_14A19E0(); //index 17
	virtual void func_14A1A30(); //index 18
	virtual void func_14A1A00(); //index 19
	virtual void func_14A1A38(); //index 20
	virtual void func_14A1908(); //index 21
	virtual void func_14A1910(); //index 22
	virtual void func_14A18E0(); //index 23
	virtual void func_14A18E8(); //index 24
	virtual void func_14A1B60(); //index 25
	virtual void func_14A1B68(); //index 26
	virtual void func_14A1B28(); //index 27
	virtual void func_14A1B30(); //index 28
	virtual void func_14A19E8(); //index 29
	virtual void func_14A1A28(); //index 30
	virtual void func_14A19F8(); //index 31
	virtual void func_14A1A08(); //index 32
	virtual void func_14A1A10(); //index 33
	virtual void func_14A1A18(); //index 34
	virtual void nullsub_0(); //index 35
	virtual void func_14C0848(); //index 36
	virtual void func_14A18F0(); //index 37
	virtual void func_14A18F8(); //index 38
	virtual void nullsub_1(); //index 39
	virtual void func_14C0858(); //index 40
	virtual void func_14C0850(); //index 41
	virtual void func_14C0860(); //index 42
	virtual void func_14A1920(); //index 43
	virtual void func_14C08B0(); //index 44
	virtual void func_14A1930(); //index 45
	virtual void func_14A1938(); //index 46
	virtual void func_14A1940(); //index 47
	virtual void func_14A1948(); //index 48
	virtual void func_14A1950(); //index 49
	virtual void func_14A1958(); //index 50
	virtual void func_14A1960(); //index 51
	virtual void func_14A1968(); //index 52
	virtual void func_14A1970(); //index 53
	virtual void func_14A1978(); //index 54
	virtual void func_14A1A40(); //index 55
	virtual void func_14C08E0(); //index 56
	virtual void func_14C08E8(); //index 57
	virtual void func_14A1A58(); //index 58
	virtual void func_14C0880(); //index 59
	virtual void func_14C0890(); //index 60
	virtual void func_14C0898(); //index 61
	virtual void func_14A1A78(); //index 62
	virtual void func_14C0888(); //index 63
	virtual void func_14A1A88(); //index 64
	virtual void nullsub_2(); //index 65
	virtual void nullsub_3(); //index 66
	virtual void nullsub_4(); //index 67
	virtual void func_14A1AA8(); //index 68
	virtual void nullsub_5(); //index 69
	virtual void func_14A1AB8(); //index 70
	virtual void func_14A1AC0(); //index 71
	virtual void func_14C0840(); //index 72
	virtual void nullsub_6(); //index 73
	virtual void nullsub_7(); //index 74
	virtual void nullsub_8(); //index 75
	virtual void func_14A1AE0(); //index 76
	virtual void func_14C08D0(); //index 77
	virtual void func_14C08D8(); //index 78
	virtual void func_14C0870(); //index 79
	virtual void func_14A1AF8(); //index 80
	virtual void func_14A1B00(); //index 81
	virtual void func_14A1B08(); //index 82
	virtual void func_14C08A0(); //index 83
	virtual void func_14A1B18(); //index 84
	virtual void func_14C08A8(); //index 85
	virtual void func_14C08B8(); //index 86
	virtual void func_14A1B40(); //index 87
	virtual void nullsub_9(); //index 88
	virtual void func_14A1B50(); //index 89
	virtual void nullsub_10(); //index 90
	virtual void func_14C08F0(); //index 91
	virtual void func_14C0908(); //index 92
	virtual void func_14A1B78(); //index 93
	virtual void nullsub_11(); //index 94
	virtual void func_14A1B88(); //index 95
	virtual void func_14A33C8(); //index 96
	virtual void func_14A33D0(); //index 97
	virtual void func_14A33D8(); //index 98
	virtual void func_14A1B90(); //index 99
	virtual void func_14C08C0(); //index 100
	virtual void func_14C0900(); //index 101
};


class MultiplayerLocalPlayer { //your local player class used for online and offline, other localplayer class is useless at all times
public:
	MultiplayerLocalPlayer* self;
	int unkptr;
	int entityId;
	char __padding000[0x0060];
	MultiPlayerLevel* pWorld;
	char __padding001[0x0054];
	double LocationX;
	double LocationY;
	double LocationZ;
	float rotYaw;
	float rotPitch;
	char __padding002[0x0004];
	LivingEntity* ridingEnt;
	char __padding003[0x0008];
	MultiPlayerLevel* pWorld1;
	char __padding004[0x0004];
	double prevPosX;
	double prevPosY;
	double prevPosZ;
	double posX;
	double posY;
	double posZ;
	double motionX;
	double motionY;
	double motionZ;
	float rotationYaw;
	float rotationPitch;
	float prevRotationYaw;
	float prevRotationPitch;
	AxisAlignedBB* boundingBox;
	bool onGround;
	bool isCollidedHorizontally;
	bool isCollidedVertically;
	bool isCollided;
	char __padding005[0x0008];
	float viewHeight1;
	float viewHeight2;
	char __padding006[0x0024];
	bool isInWeb;
	char __padding007[0x0002];
	bool isDead;
	float width;
	float height;
	float prevDistanceWalkedModified;
	float distanceWalkedModified;
	float distanceWalkedOnStepModified;
	float fallDistance;
	int unk1;
	int nextStepDistance;
	float unkfloat1;
	float unkfloat2;
	double lastTickPosX;
	double lastTickPosY;
	double lastTickPosZ;
	float stepHeight;
	bool noClip;
	char __padding008[0x000B];
	int ticksExisted;
	bool inWater;
	char __padding009[0x0003];
	int hurtResistantTime;
	char unk;
	bool dontRenderFire;
	char __padding00A[0x000E];
	int chunkCoordX;
	int chunkCoordY;
	int chunkCoordZ;
	char __padding00B[0x0024];
	int timeUntilPortal;
	bool inPortal;
	char __padding00C[0x0007];
	int dimension;
	char __padding00D[0x0018];
	const wchar_t* name;
	char __padding00E[0x0045];
	bool sliding;
	char __padding00F[0x0006];
	int ptr_tomoreptrs;
	char __padding010[0x0090];
	ModifiableAttributeMap* AttributeMap;

	virtual void destructor1(); //index 0
	virtual void destructor2(); //index 1
	virtual void nullsub_0(); //index 2
	virtual void func_14C05F0(); //index 3
	virtual void func_14A69F0(); //index 4
	virtual uint32_t getPosition(uint32_t r4); //index 5
	virtual void func_149BD18(); //index 6
	virtual MultiPlayerLevel* getEntityWorld(); //index 7
	virtual void func_149BD28(); //index 8
	virtual void func_14A6A58(); //index 9
	virtual void func_149BD38(); //index 10
	virtual void func_149BD40(); //index 11
	virtual uint32_t GetType(); //index 12
	virtual void func_14A1BB0(); //index 13
	virtual void func_14A1B98(); //index 14
	virtual void func_14A66D8(); //index 15
	virtual void func_14A6778(); //index 16
	virtual void setDead(); //index 17
	virtual void nullsub_1(); //index 18
	virtual void func_149B760(); //index 19
	virtual void SetPosition(double x, double y, double z); //index 20
	virtual void func_14C0798(); //index 21
	virtual void onEntityUpdate(); //index 22
	virtual void func_149B778(); //index 23
	virtual void func_14A6700(); //index 24
	virtual void SetFire(uint32_t r4); //index 25
	virtual void extinguish(); //index 26
	virtual void func_14A1E50(); //index 27
	virtual void func_14C06B0(); //index 28
	virtual void func_149B7A8(); //index 29
	virtual void func_149B7B0(); //index 30
	virtual void func_14A6720(); //index 31
	virtual void func_14A6728(); //index 32
	virtual void func_14A6730(); //index 33
	virtual void func_149B7D0(); //index 34
	virtual void nullsub_2(); //index 35
	virtual void func_149B7E0(); //index 36
	virtual void func_149B7E8(); //index 37
	virtual void func_149B7F0(); //index 38
	virtual void func_149B7F8(); //index 39
	virtual void func_14C0600(); //index 40
	virtual void func_149B808(); //index 41
	virtual void func_149B810(); //index 42
	virtual bool hasNoGravity(); //index 43
	virtual void SetNoGravity(bool noGravity); //index 44
	virtual void func_149B828(); //index 45
	virtual void func_149B830(); //index 46
	virtual void func_14A69D0(); //index 47
	virtual void func_14A1BC8(); //index 48
	virtual uint32_t getCollisionBoundingBox(); //index 49
	virtual void dealFireDamage(uint32_t amount); //index 50
	virtual void func_14A6958(); //index 51
	virtual bool isInWater(); //index 52
	virtual void func_149B868(); //index 53
	virtual void func_149B870(); //index 54
	virtual void func_149B878(); //index 55
	virtual void func_14A6960(); //index 56
	virtual void spawnRunningParticles(); //index 57
	virtual void createRunningParticles(); //index 58
	virtual void func_149B898(); //index 59
	virtual void func_149B8A0(); //index 60
	virtual void func_14A1F18(); //index 61
	virtual float getBrightness(); //index 62
	virtual void setWorld(MultiPlayerLevel* mpLevel); //index 63
	virtual void setLocationAndAngles(double x, double y, double z, float yaw, float pitch); //index 64
	virtual void nullsub_3(); //index 65
	virtual void func_14A6A70(); //index 66
	virtual void func_149B8D8(); //index 67
	virtual void func_14A1FD0(); //index 68
	virtual void func_14C0788(); //index 69
	virtual void func_14C0558(); //index 70
	virtual void func_14BCC80(); //index 71
	virtual void func_14A1FC8(); //index 72
	virtual void nullsub_4(); //index 73
	virtual void func_149B910(); //index 74
	virtual void func_149B918(); //index 75
	virtual void func_14A66E0(); //index 76
	virtual void func_149B928(); //index 77
	virtual void func_149B930(); //index 78
	virtual void func_14A66E8(); //index 79
	virtual void func_149B940(); //index 80
	virtual void func_14A67D8(); //index 81
	virtual void func_14A67E0(); //index 82
	virtual void nullsub_5(); //index 83
	virtual void func_149B948(); //index 84
	virtual void func_149B950(); //index 85
	virtual void func_149B958(); //index 86
	virtual void func_149B960(); //index 87
	virtual bool IsAlive(); //index 88
	virtual void func_14C0578(); //index 89
	virtual void func_149B978(); //index 90
	virtual void func_149B980(); //index 91
	virtual void func_14C06A0(); //index 92
	virtual void func_149B990(); //index 93
	virtual void nullsub_6(); //index 94
	virtual double getRidingHeight(); //index 95
	virtual double getRideHeight(); //index 96
	virtual void func_149B9B0(); //index 97
	virtual void func_149B9B8(); //index 98
	virtual void func_14C0810(); //index 99
	virtual void func_149B9C8(); //index 100
	virtual void func_149B9D0(); //index 101
	virtual void func_149B9D8(); //index 102
	virtual void func_149B9E0(); //index 103
	virtual void func_149B9E8(); //index 104
	virtual void func_14C0550(); //index 105
	virtual void func_149B9F8(); //index 106
	virtual void func_149BA00(); //index 107
	virtual void func_149BA08(); //index 108
	virtual void func_149BA10(); //index 109
	virtual void func_14A1F80(); //index 110
	virtual void func_149BA20(); //index 111
	virtual void func_149BA28(); //index 112
	virtual void func_149BA30(); //index 113
	virtual void func_149BA38(); //index 114
	virtual void func_149BA40(); //index 115
	virtual void func_14A6738(); //index 116
	virtual void setVelocity(double x, double y, double z); //index 117
	virtual void func_14C05E8(); //index 118
	virtual void func_14A1DD8(); //index 119
	virtual void func_14A6A10(); //index 120
	virtual void func_14A6A18(); //index 121
	virtual void func_149BA78(); //index 122
	virtual void func_14A6A08(); //index 123
	virtual bool IsBurning(); //index 124
	virtual void func_149BA90(); //index 125
	virtual void func_149BA98(); //index 126
	virtual bool IsSneaking(); //index 127
	virtual void setSneaking(); //index 128
	virtual void func_149BAB0(); //index 129
	virtual void setIsIdle(); //index 130
	virtual bool IsSprinting(); //index 131
	virtual void setSprinting(bool sprint); //index 132
	virtual void func_149BAD0(); //index 133
	virtual void func_149BAD8(); //index 134
	virtual void func_149BAE0(); //index 135
	virtual void func_149BAE8(); //index 136
	virtual void func_149BAF0(); //index 137
	virtual void func_14C0768(); //index 138
	virtual void func_14C0770(); //index 139
	virtual void func_149BB08(); //index 140
	virtual void func_149BB10(); //index 141
	virtual void func_14C0560(); //index 142
	virtual void func_14A6A20(); //index 143
	virtual void func_14A6A38(); //index 144
	virtual void func_149BB30(); //index 145
	virtual void func_149BB38(); //index 146
	virtual void func_14A8500(); //index 147
	virtual void func_14A8528(); //index 148
	virtual void func_149BB50(); //index 149
	virtual void func_14A6AB0(); //index 150
	virtual void func_149B718(); //index 151
	virtual void func_149BB60(); //index 152
	virtual void onStruckByLightning(); //index 153
	virtual void func_149BB70(); //index 154
	virtual void func_14A6970(); //index 155
	virtual bool pushOutOfBlocks(double x, double y, double z); //index 156
	virtual void func_14A1E10(); //index 157
	virtual void func_14A6978(); //index 158
	virtual void func_14A69E8(); //index 159
	virtual void func_149BBA0(); //index 160
	virtual void func_149BBA8(); //index 161
	virtual void SetInvulnerable(); //index 162
	virtual void func_149BBB8(); //index 163
	virtual void func_149BBC0(); //index 164
	virtual void func_14A1FD8(); //index 165
	virtual void func_14A1FE0(); //index 166
	virtual void func_14A1FE8(); //index 167
	virtual bool canBeAttackedWithItem(); //index 168
	virtual uint32_t hitByEntity(); //index 169
	virtual void copyLocationAndAnglesFrom(uint32_t r4); //index 170
	virtual void func_14C06B8(); //index 171
	virtual void func_149BC00(); //index 172
	virtual void func_149BC08(); //index 173
	virtual bool verifyExplosion(); //index 174
	virtual uint32_t getMaxFallHeight(); //index 175
	virtual void func_149BC20(); //index 176
	virtual void func_149BC28(); //index 177
	virtual void func_149BC30(); //index 178
	virtual uint32_t doesEntityNotTriggerPressurePlate(); //index 179
	virtual bool canRenderOnFire(); //index 180
	virtual void func_149BC48(); //index 181
	virtual void func_149BC50(); //index 182
	virtual void func_149BC58(); //index 183
	virtual void func_14A6A28(); //index 184
	virtual double getRenderDistanceWeight(); //index 185
	virtual void setRenderDistanceWeight(double dist); //index 186
	virtual void func_14A69F8(); //index 187
	virtual void func_149BC88(); //index 188
	virtual void func_149BC90(); //index 189
	virtual void func_149BC98(); //index 190
	virtual void func_149BCA0(); //index 191
	virtual void func_149BCA8(); //index 192
	virtual void func_149BCB0(); //index 193
	virtual void func_14A69C8(); //index 194
	virtual void func_14C0630(); //index 195
	virtual void func_149BCC8(); //index 196
	virtual void func_149BCD0(); //index 197
	virtual void func_149BCD8(); //index 198
	virtual void func_149BCE0(); //index 199
	virtual void func_14A1F20(); //index 200
	virtual float getViewHeight(); //index 201
	virtual void func_14A6A60(); //index 202
	virtual void func_149BD48(); //index 203
	virtual void func_149BD50(); //index 204
	virtual void nullsub_7(); //index 205
	virtual void nullsub_8(); //index 206
	virtual float getRotatedYaw(); //index 207
	virtual float getMirroredYaw(); //index 208
	virtual uint32_t ignoreItemEntityData(); //index 209
	virtual void setPositionNonDirty(); //index 210
	virtual void func_149BD88(); //index 211
	virtual void func_149BD90(); //index 212
	virtual void func_149BD98(); //index 213
	virtual void func_149BDA0(); //index 214
	virtual void func_149BDA8(); //index 215
	virtual void func_149BDB0(); //index 216
	virtual void func_149BDB8(); //index 217
	virtual void func_149BDC0(); //index 218
	virtual void func_149BDC8(); //index 219
	virtual void func_149BDD0(); //index 220
	virtual void func_149BDD8(); //index 221
	virtual void func_149BDE0(); //index 222
	virtual void func_149BDE8(); //index 223
	virtual void func_149BDF0(); //index 224
	virtual void func_14A6748(); //index 225
	virtual void func_14BCC90(); //index 226
	virtual void func_149BE08(); //index 227
	virtual void nullsub_9(); //index 228
	virtual void func_149BE18(); //index 229
	virtual void func_14A6AA0(); //index 230
	virtual void func_14A20A8(); //index 231
	virtual void func_14A8530(); //index 232
	virtual void func_14A8538(); //index 233
	virtual void func_14A8540(); //index 234
	virtual void func_14A8548(); //index 235
	virtual void func_14A8550(); //index 236
	virtual void func_14A8558(); //index 237
	virtual void nullsub_10(); //index 238
	virtual void func_1492D20(); //index 239
	virtual void nullsub_11(); //index 240
	virtual void func_14C0760(); //index 241
	virtual void func_14A6AC8(); //index 242
	virtual void func_14A6AD0(); //index 243
	virtual void func_149BE38(); //index 244
	virtual void func_149BE40(); //index 245
	virtual void func_149BE48(); //index 246
	virtual void func_149BE50(); //index 247
	virtual void func_149BE58(); //index 248
	virtual void func_149BE60(); //index 249
	virtual void func_149BE68(); //index 250
	virtual void func_149BE70(); //index 251
	virtual void func_14A66D0(); //index 252
	virtual void func_14A1BD0(); //index 253
	virtual void func_14A1BD8(); //index 254
	virtual void func_14A1BE0(); //index 255
	virtual void func_14A1BE8(); //index 256
	virtual void func_14A1BF0(); //index 257
	virtual void func_14A6708(); //index 258
	virtual void func_14A6710(); //index 259
	virtual void func_14A6718(); //index 260
	virtual void frostWalk(uint32_t r4); //index 261
	virtual bool IsChild(); //index 262
	virtual void onDeathUpdate(); //index 263
	virtual bool canDropLoot(); //index 264
	virtual void decreaseAirSupply(uint32_t r4); //index 265
	virtual void func_14A69B8(); //index 266
	virtual void func_14A69C0(); //index 267
	virtual void func_14A1C58(); //index 268
	virtual void func_14A1C60(); //index 269
	virtual void func_14A1C68(); //index 270
	virtual void func_14A1C70(); //index 271
	virtual void func_14A1C78(); //index 272
	virtual void func_14A1C80(); //index 273
	virtual void func_14A1C88(); //index 274
	virtual void func_14A1C90(); //index 275
	virtual void updatePotionEffects(); //index 276
	virtual void func_14A1CB0(); //index 277
	virtual void func_14A1CB8(); //index 278
	virtual void func_14A1CC0(); //index 279
	virtual void func_14A1CC8(); //index 280
	virtual bool isPotionActive(uint32_t potion); //index 281
	virtual uint32_t getActivePotionEffect(uint32_t potion); //index 282
	virtual void func_14A1CE0(); //index 283
	virtual void func_14A1CE8(); //index 284
	virtual bool isPotionApplicable(); //index 285
	virtual bool isEntityUndead(); //index 286
	virtual void func_14C06A8(); //index 287
	virtual void func_14A1D08(); //index 288
	virtual void func_14C07C8(); //index 289
	virtual void func_14C07D0(); //index 290
	virtual void func_14C07D8(); //index 291
	virtual void nullsub_12(); //index 292
	virtual void func_14A1D30(); //index 293
	virtual void func_14A1D38(); //index 294
	virtual void func_14A1D48(); //index 295
	virtual void func_14A6800(); //index 296
	virtual void func_14A1D58(); //index 297
	virtual void func_14A1D60(); //index 298
	virtual void func_14A1D68(); //index 299
	virtual void func_14A1D70(); //index 300
	virtual void func_14A67B0(); //index 301
	virtual void nullsub_13(); //index 302
	virtual void func_14A1D88(); //index 303
	virtual void func_14A67B8(); //index 304
	virtual void func_14A67C0(); //index 305
	virtual void func_14A6968(); //index 306
	virtual void func_14A1DA8(); //index 307
	virtual void nullsub_14(); //index 308
	virtual void func_14A1DB8(); //index 309
	virtual void func_14A1DC0(); //index 310
	virtual void func_14A1DE0(); //index 311
	virtual void func_14A6818(); //index 312
	virtual void nullsub_15(); //index 313
	virtual void func_14A1DF8(); //index 314
	virtual void func_14A1E00(); //index 315
	virtual void func_14C07B8(); //index 316
	virtual void func_14A1E18(); //index 317
	virtual void func_14A1E20(); //index 318
	virtual void func_14A1E28(); //index 319
	virtual void func_14A1E30(); //index 320
	virtual void func_14A1E38(); //index 321
	virtual void func_14C0598(); //index 322
	virtual void func_14A1E58(); //index 323
	virtual void func_14A1E60(); //index 324
	virtual void func_14A1E68(); //index 325
	virtual uint32_t getCreatureAttribute(); //index 326
	virtual void func_14A1E78(); //index 327
	virtual void func_14A1E80(); //index 328
	virtual void func_14A1E88(); //index 329
	virtual void func_14A1E90(); //index 330
	virtual void func_14A1E98(); //index 331
	virtual void func_14A6A00(); //index 332
	virtual void func_14A6980(); //index 333
	virtual void func_14A1EB0(); //index 334
	virtual void func_14A1EB8(); //index 335
	virtual void func_14A6758(); //index 336
	virtual void func_14A1EC8(); //index 337
	virtual float getJumpUpwardsMotion(); //index 338
	virtual void func_14A6938(); //index 339
	virtual void func_14A1EE8(); //index 340
	virtual void func_14A1EF0(); //index 341
	virtual void func_14A1EF8(); //index 342
	virtual float getWaterSlowDown(); //index 343
	virtual void func_14A6940(); //index 344
	virtual void func_14A1F10(); //index 345
	virtual void func_14A6948(); //index 346
	virtual void func_14A1F30(); //index 347
	virtual void func_14A1F38(); //index 348
	virtual void func_14A68F8(); //index 349
	virtual void func_14C0690(); //index 350
	virtual void onLivingUpdate(); //index 351
	virtual void func_14C0688(); //index 352
	virtual void func_14A6A78(); //index 353
	virtual void func_14A1F70(); //index 354
	virtual void func_14A1F88(); //index 355
	virtual void func_14A1F90(); //index 356
	virtual void func_14A1F98(); //index 357
	virtual void func_14A1FA8(); //index 358
	virtual void func_14A1FB0(); //index 359
	virtual bool isServerWorld(); //index 360
	virtual void func_14A6A50(); //index 361
	virtual void func_14A6A48(); //index 362
	virtual void nullsub_16(); //index 363
	virtual void nullsub_17(); //index 364
	virtual void func_14A2010(); //index 365
	virtual void func_14A6A68(); //index 366
	virtual bool isHandActive(); //index 367
	virtual uint32_t getActiveHand(); //index 368
	virtual void func_14A2028(); //index 369
	virtual void func_14C0610(); //index 370
	virtual void func_14A2040(); //index 371
	virtual void func_14C07C0(); //index 372
	virtual void func_14A2050(); //index 373
	virtual void func_14A2058(); //index 374
	virtual void func_14A2060(); //index 375
	virtual void resetActiveHand(); //index 376
	virtual void func_14A2070(); //index 377
	virtual void func_14A2078(); //index 378
	virtual void func_14A2080(); //index 379
	virtual void func_14A2088(); //index 380
	virtual void func_14A2090(); //index 381
	virtual void nullsub_18(); //index 382
	virtual void func_14A6A98(); //index 383
	virtual void func_14A66F0(); //index 384
	virtual void func_14C07E0(); //index 385
	virtual void func_14A6790(); //index 386
	virtual void func_14A6798(); //index 387
	virtual void func_14A67A0(); //index 388
	virtual void func_14A67A8(); //index 389
	virtual void func_14C0588(); //index 390
	virtual void func_14C07A8(); //index 391
	virtual void func_14C06D8(); //index 392
	virtual void func_14C06E0(); //index 393
	virtual void func_14C06E8(); //index 394
	virtual void func_14A67E8(); //index 395
	virtual void func_14A67F0(); //index 396
	virtual void func_14A6808(); //index 397
	virtual void func_14A6810(); //index 398
	virtual void func_14A6820(); //index 399
	virtual void func_14C0638(); //index 400
	virtual void nullsub_19(); //index 401
	virtual void nullsub_20(); //index 402
	virtual void func_14C0648(); //index 403
	virtual void func_14C0650(); //index 404
	virtual void func_14C0658(); //index 405
	virtual void func_14C0660(); //index 406
	virtual void func_14C0668(); //index 407
	virtual void func_14A6878(); //index 408
	virtual void func_14A6890(); //index 409
	virtual void nullsub_21(); //index 410
	virtual void func_14C0670(); //index 411
	virtual void func_14C0678(); //index 412
	virtual void func_14C07B0(); //index 413
	virtual void func_14C07F8(); //index 414
	virtual void func_14A68D8(); //index 415
	virtual void func_14A68E8(); //index 416
	virtual void func_14A68F0(); //index 417
	virtual void func_14C06C8(); //index 418
	virtual void func_14A6908(); //index 419
	virtual void func_14A6910(); //index 420
	virtual void func_14A6918(); //index 421
	virtual void func_14A6920(); //index 422
	virtual void func_14C07F0(); //index 423
	virtual void nullsub_22(); //index 424
	virtual void func_14A6950(); //index 425
	virtual void func_14A6988(); //index 426
	virtual void func_14A6990(); //index 427
	virtual void func_14A6998(); //index 428
	virtual void func_14A69A0(); //index 429
	virtual void func_14A69A8(); //index 430
	virtual void func_14A69B0(); //index 431
	virtual void func_14C05B8(); //index 432
	virtual void nullsub_23(); //index 433
	virtual bool IsSpectator(); //index 434
	virtual void func_14A6A30(); //index 435
	virtual void func_14C06F0(); //index 436
	virtual void func_14A6A80(); //index 437
	virtual void func_14A6A88(); //index 438
	virtual void func_14A6A90(); //index 439
	virtual void func_14C0710(); //index 440
	virtual void func_14A6AA8(); //index 441
	virtual void func_14C0730(); //index 442
	virtual void func_14C0738(); //index 443
	virtual void func_14C0740(); //index 444
	virtual void func_14A6AB8(); //index 445
	virtual void func_14C0720(); //index 446
	virtual void func_14C0728(); //index 447
	virtual void func_14A6AC0(); //index 448
	virtual void func_14C0750(); //index 449
	virtual void func_14C0758(); //index 450
	virtual void func_14C0718(); //index 451
	virtual void func_14C0580(); //index 452
	virtual void getPermissionLevel(); //index 453
	virtual void setPermissionLevel(uint32_t permissionLevel); //index 454
	virtual void func_14C06C0(); //index 455
	virtual void func_14C0820(); //index 456
	virtual void func_14C0828(); //index 457
	virtual void func_14C0708(); //index 458
	virtual void func_14C0748(); //index 459
	virtual void func_14C07A0(); //index 460
	virtual void func_14C07E8(); //index 461
	virtual void func_14C0800(); //index 462
	virtual void func_14C0808(); //index 463
	virtual void func_14C0818(); //index 464

};

class BlockPos { //basic "vec3" class just named as BlockPos as that is what mc calls it
public:
	int x;
	int y;
	int z;
	BlockPos(int x, int y, int z);
	BlockPos(double x, double y, double z);
};

class Minecraft {
public:
	DataFixerUpper* cDataFixerUpper;
	MultiPlayerGameMode* cMultiPlayerGameMode;
	char __padding000[0x0008];
	int displayWidth;
	int displayHeight;
	int displayWidth1;
	int displayHeight1;
	Timer* cTimer;
	char __padding001[0x0008];
	MultiPlayerLevel* cMultiPlayerLevel;
	LevelRenderer* cLevelRenderer;
	MultiplayerLocalPlayer* cMultiplayerLocalPlayer;
	char __padding002[0x000C];
	MultiplayerLocalPlayer* cMultiplayerLocalPlayer1;
	char __padding003[0x0018];
	MultiPlayerGameMode* cMultiPlayerGameMode1;
	char __padding004[0x0010];
	uint32_t unknownptr[4];
	char __padding005[0x003C];
	MultiplayerLocalPlayer* cMultiplayerLocalPlayer2;
	char __padding006[0x000C];
	uint32_t unknownptr1[2];
	char __padding007[0x0028];
	uint32_t fontRenderer;
};

class TheMinecraft
{
public:
	Minecraft* theMinecraft;
	char __padding000[0x0020];
	uint32_t gameTime;
	char __padding001[0x0080];
	uint32_t FPS;
};

struct temp_t {
	char __padding000[0x00C8];
	Vector3 pos;
};




































///////////////////////////////////////////////////

class IntRectangle;
class Color;
class Font;

namespace mce
{
	class TexturePtr;
	class MaterialPtr;
};

// Size : 1
class ScreenRenderer
{
public:
	static ScreenRenderer* singletonPtr;

public:
	ScreenRenderer();
	void blit(mce::TexturePtr const&, IntRectangle const&);
	void blit(mce::TexturePtr const&, float, float, int, int, float, float, int, int, mce::MaterialPtr*);
	void blit(mce::TexturePtr const&, int, int, int, int, int, int, int, int, mce::MaterialPtr*);
	void blitRaw(mce::TexturePtr const&, float, float, float, float, float, float, float, float, float);
	void drawCenteredString(Font*, std::string const&, int, int, Color const&);
	void drawRect(int, int, int, int, Color const&, Color const&, Color const&, Color const&, int);
	void drawRect(int, int, int, int, Color const&, int);
	void drawString(Font*, std::string const&, int, int, Color const&);
	void fill(float, float, float, float, Color const&);
	void fill(int, int, int, int, Color const&);
	void fillGradient(float, float, float, float, Color const&, Color const&);
	void fillGradient(int, int, int, int, Color const&, Color const&);
	void fillHorizontalGradient(float, float, float, float, Color const&, Color const&);
	void fillHorizontalGradient(int, int, int, int, Color const&, Color const&);
	void fillStencil(float, float, float, float);
	void getMaterial(void* ScreenMaterial);
	void reloadResources(void*); // TextureGroup  &
	void singleton();
};


class GuiComponent : public ScreenRenderer
{
public:
	//void **vtable;				// 0

public:
	GuiComponent();
	virtual ~GuiComponent();
};

class EntityDamageSource;

class Entity1
{
public:
	void* m_vTable; //0x0000 
	uintptr_t m_this; //0x0004 
	MultiplayerLocalPlayer* m_multiplayerLocalPlayer; //0x0008 
	uint32_t entityId; //0x000C 
	char _0x0010[96];
	MultiPlayerLevel* m_multiPlayerLevel; //0x0070 
	char _0x0084[98];
	Vector2 m_prevViewAngles; //0x00E0 
	char _0x00E8[4];
	uintptr_t* m_vehicle; //0x00EC 
	uintptr_t* m_vehicle2; //0x00F0 
	char _0x00F4[4];
	MultiPlayerLevel* m_multiPlayerLevel2; //0x00F8 
	char _0x00FC[4];
	Vector3 m_pos; //0x0100 
	Vector3 m_lastPos; //0x010C 
	Vector3 m_motion; //0x0118 
	Vector3 m_rotation; //0x0124 
	Vector3 m_lastRotation; //0x0130 
	Vector3 m_pos3; //0x013C 
	Vector3 m_viewAngles; //0x0148 
	Vector3 m_viewAngles2; //0x0150 
	uint8_t N59AD4F87; //0x015C 
	uint8_t N59B24B77; //0x015D 
	uint8_t m_OnGround; //0x015E 
	uint8_t m_OnGround2; //0x015F 
	char _0x0160[4];
	uint8_t m_fireTicks; //0x0164 
	uint8_t m_fireTicks2; //0x0165 
	uint8_t N59BCF42D; //0x0166 
	uint8_t N59BCE6CD; //0x0167 
	char _0x0168[44];
	uint8_t m_isInWeb; //0x0194 
	uint8_t m_isOutsideBorder; //0x0195 
	uint8_t N59BE0FD5; //0x0196 
	uint8_t N59BE03CD; //0x0197 
	char _0x0198[68];
	uint8_t m_collision; //0x01DC 
	char _0x01DD[15];
	uint8_t m_isInwater; //0x01EC 
	uint8_t m_headInWater; //0x01ED 
	uint16_t m_unknown001; //0x01EE 
	char _0x01F0[8];
	uintptr_t* m_dataItems; //0x01F8 
	uint32_t* m_SynchedEntityData; //0x01FC 
	char _0x0200[320];
	uint32_t* m_ModifiableAttributeMap; //0x0340 
	char _0x0344[40];
	char _0x0370[12];
	char _0x0380[880];
	uint8_t m_portalWaitTime; //0x06F0 
	uint8_t m_isOnGround; //0x06F1 
	uint8_t m_setCanFly; //0x06F2 
	uint8_t N59C4BBB3; //0x06F3 
	char _0x06F4[12];
	uint32_t m_xpLevel; //0x0700 
	uint32_t m_xpAmount; //0x0704 
	char _0x0708[236];
	uint16_t N59C3298B; //0x07F4 
	uint16_t m_hostPrivilegesFlags; //0x07F6		  0xF990 = invisible   0xF810 = visible   0xF830 = can fly   0xF850 = disable exhaustion  0xFA10 = creative  0x1A00 = in mini game
	char _0x07F8[232];
	float m_timeInPortal; //0x08E0 
	char _0x08E4[420];
};