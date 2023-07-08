#pragma once

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