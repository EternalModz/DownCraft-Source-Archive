// xstring internal header (from <string>)
#pragma once
#ifndef _XSTRING_
#define _XSTRING_
#ifndef RC_INVOKED
#include <xmemory0>

#pragma pack(push,_CRT_PACKING)
#pragma warning(push,_STL_WARNING_LEVEL)
#pragma warning(disable: _STL_DISABLED_WARNINGS)
#pragma push_macro("new")
#undef new

_STD_BEGIN
template<class _Traits>
using _Traits_ch_t = typename _Traits::char_type;

template<class _Traits>
using _Traits_ptr_t = const typename _Traits::char_type *;

template<class _Traits>
constexpr bool _Traits_equal(_In_reads_(_Left_size) const _Traits_ptr_t<_Traits> _Left, const size_t _Left_size,
	_In_reads_(_Right_size) const _Traits_ptr_t<_Traits> _Right, const size_t _Right_size) _NOEXCEPT
{	// compare [_Left, _Left + _Left_size) to [_Right, _Right + _Right_size) for equality using _Traits
	return (_Left_size == _Right_size && _Traits::compare(_Left, _Right, _Left_size) == 0);
}

template<class _Traits>
constexpr int _Traits_compare(_In_reads_(_Left_size) const _Traits_ptr_t<_Traits> _Left, const size_t _Left_size,
	_In_reads_(_Right_size) const _Traits_ptr_t<_Traits> _Right, const size_t _Right_size) _NOEXCEPT
{	// compare [_Left, _Left + _Left_size) to [_Right, _Right + _Right_size) using _Traits
	const int _Ans = _Traits::compare(_Left, _Right, _Min_value(_Left_size, _Right_size));

	if (_Ans != 0)
	{
		return (_Ans);
	}

	if (_Left_size < _Right_size)
	{
		return (-1);
	}

	if (_Left_size > _Right_size)
	{
		return (1);
	}

	return (0);
}

template<class _Traits>
constexpr size_t _Traits_find(
	_In_reads_(_Hay_size) const _Traits_ptr_t<_Traits> _Haystack, const size_t _Hay_size, const size_t _Start_at,
	_In_reads_(_Needle_size) const _Traits_ptr_t<_Traits> _Needle, const size_t _Needle_size) _NOEXCEPT
{	// search [_Haystack, _Haystack + _Hay_size) for [_Needle, _Needle + _Needle_size), at/after _Start_at
	if (_Needle_size > _Hay_size || _Start_at > _Hay_size - _Needle_size)
	{	// xpos cannot exist, report failure
		// N4659 24.3.2.7.2 [string.find]/1 says:
		// 1. _Start_at <= xpos
		// 2. xpos + _Needle_size <= _Hay_size;
		// therefore:
		// 3. _Needle_size <= _Hay_size (by 2) (checked above)
		// 4. _Start_at + _Needle_size <= _Hay_size (substitute 1 into 2)
		// 5. _Start_at <= _Hay_size - _Needle_size (4, move _Needle_size to other side) (also checked above)
		return (static_cast<size_t>(-1));
	}

	if (_Needle_size == 0)
	{	// empty string always matches if xpos is possible
		return (_Start_at);
	}

	const auto _Possible_matches_end = _Haystack + (_Hay_size - _Needle_size) + 1;
	for (auto _Match_try = _Haystack + _Start_at; ; ++_Match_try)
	{
		_Match_try = _Traits::find(_Match_try, _Possible_matches_end - _Match_try, *_Needle);
		if (!_Match_try)
		{	// didn't find first character; report failure
			return (static_cast<size_t>(-1));
		}

		if (_Traits::compare(_Match_try, _Needle, _Needle_size) == 0)
		{	// found match
			return (_Match_try - _Haystack);
		}
	}
}

template<class _Traits>
constexpr size_t _Traits_find_ch(
	_In_reads_(_Hay_size) const _Traits_ptr_t<_Traits> _Haystack, const size_t _Hay_size, const size_t _Start_at,
	const _Traits_ch_t<_Traits> _Ch) _NOEXCEPT
{	// search [_Haystack, _Haystack + _Hay_size) for _Ch, at/after _Start_at
	if (_Start_at < _Hay_size)
	{
		const auto _Found_at = _Traits::find(_Haystack + _Start_at, _Hay_size - _Start_at, _Ch);
		if (_Found_at)
		{
			return (_Found_at - _Haystack);
		}
	}

	return (static_cast<size_t>(-1));	// (npos) no match
}

template<class _Traits>
constexpr size_t _Traits_rfind(
	_In_reads_(_Hay_size) const _Traits_ptr_t<_Traits> _Haystack, const size_t _Hay_size, const size_t _Start_at,
	_In_reads_(_Needle_size) const _Traits_ptr_t<_Traits> _Needle, const size_t _Needle_size) _NOEXCEPT
{	// search [_Haystack, _Haystack + _Hay_size) for [_Needle, _Needle + _Needle_size) beginning before _Start_at
	if (_Needle_size == 0)
	{
		return (_Min_value(_Start_at, _Hay_size));	// empty string always matches
	}

	if (_Needle_size <= _Hay_size)
	{	// room for match, look for it
		for (auto _Match_try = _Haystack + _Min_value(_Start_at, _Hay_size - _Needle_size); ; --_Match_try)
		{
			if (_Traits::eq(*_Match_try, *_Needle)
				&& _Traits::compare(_Match_try, _Needle, _Needle_size) == 0)
			{
				return (_Match_try - _Haystack);	// found a match
			}

			if (_Match_try == _Haystack)
			{
				break;	// at beginning, no more chance for match
			}
		}
	}

	return (static_cast<size_t>(-1));	// no match
}

template<class _Traits>
constexpr size_t _Traits_rfind_ch(
	_In_reads_(_Hay_size) const _Traits_ptr_t<_Traits> _Haystack, const size_t _Hay_size, const size_t _Start_at,
	const _Traits_ch_t<_Traits> _Ch) _NOEXCEPT
{	// search [_Haystack, _Haystack + _Hay_size) for _Ch before _Start_at
	if (_Hay_size != 0)
	{	// room for match, look for it
		for (auto _Match_try = _Haystack + _Min_value(_Start_at, _Hay_size - 1); ; --_Match_try)
		{
			if (_Traits::eq(*_Match_try, _Ch))
			{
				return (_Match_try - _Haystack);	// found a match
			}

			if (_Match_try == _Haystack)
			{
				break;	// at beginning, no more chance for match
			}
		}
	}

	return (static_cast<size_t>(-1));	// no match
}

template<class _Traits>
constexpr size_t _Traits_find_first_of(
	_In_reads_(_Hay_size) const _Traits_ptr_t<_Traits> _Haystack, const size_t _Hay_size, const size_t _Start_at,
	_In_reads_(_Needle_size) const _Traits_ptr_t<_Traits> _Needle, const size_t _Needle_size) _NOEXCEPT
{	// in [_Haystack, _Haystack + _Hay_size), look for one of [_Needle, _Needle + _Needle_size), at/after _Start_at
	if (_Needle_size != 0 && _Start_at < _Hay_size)
	{	// room for match, look for it
		const auto _End = _Haystack + _Hay_size;
		for (auto _Match_try = _Haystack + _Start_at; _Match_try < _End; ++_Match_try)
		{
			if (_Traits::find(_Needle, _Needle_size, *_Match_try))
			{
				return (_Match_try - _Haystack);	// found a match
			}
		}
	}

	return (static_cast<size_t>(-1));	// no match
}

template<class _Traits>
constexpr size_t _Traits_find_last_of(
	_In_reads_(_Hay_size) const _Traits_ptr_t<_Traits> _Haystack, const size_t _Hay_size, const size_t _Start_at,
	_In_reads_(_Needle_size) const _Traits_ptr_t<_Traits> _Needle, const size_t _Needle_size) _NOEXCEPT
{	// in [_Haystack, _Haystack + _Hay_size), look for last of [_Needle, _Needle + _Needle_size), before _Start_at
	if (_Needle_size != 0 && _Hay_size != 0)
	{	// worth searching, do it
		for (auto _Match_try = _Haystack + _Min_value(_Start_at, _Hay_size - 1); ; --_Match_try)
		{
			if (_Traits::find(_Needle, _Needle_size, *_Match_try))
			{
				return (_Match_try - _Haystack);	// found a match
			}

			if (_Match_try == _Haystack)
			{
				break;	// at beginning, no more chance for match
			}
		}
	}

	return (static_cast<size_t>(-1));	// no match
}

template<class _Traits>
constexpr size_t _Traits_find_first_not_of(
	_In_reads_(_Hay_size) const _Traits_ptr_t<_Traits> _Haystack, const size_t _Hay_size, const size_t _Start_at,
	_In_reads_(_Needle_size) const _Traits_ptr_t<_Traits> _Needle, const size_t _Needle_size) _NOEXCEPT
{	// in [_Haystack, _Haystack + _Hay_size), look for none of [_Needle, _Needle + _Needle_size), at/after _Start_at
	if (_Start_at < _Hay_size)
	{	// room for match, look for it
		const auto _End = _Haystack + _Hay_size;
		for (auto _Match_try = _Haystack + _Start_at; _Match_try < _End; ++_Match_try)
		{
			if (!_Traits::find(_Needle, _Needle_size, *_Match_try))
			{
				return (_Match_try - _Haystack);	// found a match
			}
		}
	}

	return (static_cast<size_t>(-1));	// no match
}

template<class _Traits>
constexpr size_t _Traits_find_not_ch(
	_In_reads_(_Hay_size) const _Traits_ptr_t<_Traits> _Haystack, const size_t _Hay_size, const size_t _Start_at,
	const _Traits_ch_t<_Traits> _Ch) _NOEXCEPT
{	// search [_Haystack, _Haystack + _Hay_size) for any value other than _Ch, at/after _Start_at
	if (_Start_at < _Hay_size)
	{	// room for match, look for it
		const auto _End = _Haystack + _Hay_size;
		for (auto _Match_try = _Haystack + _Start_at; _Match_try < _End; ++_Match_try)
		{
			if (!_Traits::eq(*_Match_try, _Ch))
			{
				return (_Match_try - _Haystack);	// found a match
			}
		}
	}

	return (static_cast<size_t>(-1));	// no match
}

template<class _Traits>
constexpr size_t _Traits_find_last_not_of(
	_In_reads_(_Hay_size) const _Traits_ptr_t<_Traits> _Haystack, const size_t _Hay_size, const size_t _Start_at,
	_In_reads_(_Needle_size) const _Traits_ptr_t<_Traits> _Needle, const size_t _Needle_size) _NOEXCEPT
{	// in [_Haystack, _Haystack + _Hay_size), look for none of [_Needle, _Needle + _Needle_size), before _Start_at
	if (_Hay_size != 0)
	{	// worth searching, do it
		for (auto _Match_try = _Haystack + _Min_value(_Start_at, _Hay_size - 1); ; --_Match_try)
		{
			if (!_Traits::find(_Needle, _Needle_size, *_Match_try))
			{
				return (_Match_try - _Haystack);	// found a match
			}

			if (_Match_try == _Haystack)
			{
				break;	// at beginning, no more chance for match
			}
		}
	}

	return (static_cast<size_t>(-1));	// no match
}

template<class _Traits>
constexpr size_t _Traits_rfind_not_ch(
	_In_reads_(_Hay_size) const _Traits_ptr_t<_Traits> _Haystack, const size_t _Hay_size, const size_t _Start_at,
	const _Traits_ch_t<_Traits> _Ch) _NOEXCEPT
{	// search [_Haystack, _Haystack + _Hay_size) for any value other than _Ch before _Start_at
	if (_Hay_size != 0)
	{	// room for match, look for it
		for (auto _Match_try = _Haystack + _Min_value(_Start_at, _Hay_size - 1); ; --_Match_try)
		{
			if (!_Traits::eq(*_Match_try, _Ch))
			{
				return (_Match_try - _Haystack);	// found a match
			}

			if (_Match_try == _Haystack)
			{
				break;	// at beginning, no more chance for match
			}
		}
	}

	return (static_cast<size_t>(-1));	// no match
}


#if _HAS_CXX17
// CLASS TEMPLATE _String_view_iterator
template<class _Elem,
	class _Traits = char_traits<_Elem>>
	class basic_string_view;

template<class _Traits>
class _String_view_iterator;

template<class _Traits>
constexpr _String_view_iterator<_Traits>& _Rechecked(_String_view_iterator<_Traits>& _Iter,
	typename _String_view_iterator<_Traits>::_Unchecked_type _Right) _NOEXCEPT;
template<class _Traits>
constexpr typename _String_view_iterator<_Traits>::_Unchecked_type _Unchecked(
	_String_view_iterator<_Traits>) _NOEXCEPT;

template<class _Traits>
class _String_view_iterator
{	// iterator for character buffer wrapper
public:
	using iterator_category = random_access_iterator_tag;
	using value_type = typename _Traits::char_type;
	using difference_type = ptrdiff_t;
	using pointer = const value_type *;
	using reference = const value_type&;

	using _Unchecked_type = pointer;

	constexpr _String_view_iterator() _NOEXCEPT
#if _ITERATOR_DEBUG_LEVEL >= 1
		: _Mydata(),
		_Mysize(0),
		_Myoff(0)
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		: _Myptr()
#endif /* _ITERATOR_DEBUG_LEVEL */
	{	// default-initialize a basic_string_view::const_iterator
	}

private:
	friend basic_string_view<value_type, _Traits>;
	friend constexpr _String_view_iterator& _Rechecked<>(_String_view_iterator& _Iter,
		_Unchecked_type _Right) _NOEXCEPT;
	friend constexpr _Unchecked_type _Unchecked<>(_String_view_iterator) _NOEXCEPT;

#if _ITERATOR_DEBUG_LEVEL >= 1
	constexpr _String_view_iterator(const pointer _Data, const size_t _Size, const size_t _Off) _NOEXCEPT
		: _Mydata(_Data),
		_Mysize(_Size),
		_Myoff(_Off)
	{	// initialize a basic_string_view::const_iterator
	}
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
	constexpr explicit _String_view_iterator(const pointer _Ptr) _NOEXCEPT
		: _Myptr(_Ptr)
	{	// initialize a basic_string_view::const_iterator
	}
#endif /* _ITERATOR_DEBUG_LEVEL */

public:
	constexpr reference operator*() const _NOEXCEPT
	{	// return designated object
#if _ITERATOR_DEBUG_LEVEL >= 1
		_IDL_VERIFY(_Mydata, "cannot dereference value-initialized string_view iterator");
		_IDL_VERIFY(_Myoff < _Mysize, "cannot dereference end string_view iterator");
		return (_Mydata[_Myoff]);
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		return (*_Myptr);
#endif /* _ITERATOR_DEBUG_LEVEL */
	}

	constexpr pointer operator->() const _NOEXCEPT
	{	// return pointer to class object
#if _ITERATOR_DEBUG_LEVEL >= 1
		_IDL_VERIFY(_Mydata, "cannot dereference value-initialized string_view iterator");
		_IDL_VERIFY(_Myoff < _Mysize, "cannot dereference end string_view iterator");
		return (_Mydata + _Myoff);
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		return (_Myptr);
#endif /* _ITERATOR_DEBUG_LEVEL */
	}

	constexpr _String_view_iterator& operator++() _NOEXCEPT
	{	// preincrement
#if _ITERATOR_DEBUG_LEVEL >= 1
		_IDL_VERIFY(_Mydata, "cannot increment value-initialized string_view iterator");
		_IDL_VERIFY(_Myoff < _Mysize, "cannot increment string_view iterator past end");
		++_Myoff;
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		++_Myptr;
#endif /* _ITERATOR_DEBUG_LEVEL */
		return (*this);
	}

	constexpr _String_view_iterator operator++(int) _NOEXCEPT
	{	// postincrement
		_String_view_iterator _Tmp{ *this };
		++*this;
		return (_Tmp);
	}

	constexpr _String_view_iterator& operator--() _NOEXCEPT
	{	// predecrement
#if _ITERATOR_DEBUG_LEVEL >= 1
		_IDL_VERIFY(_Mydata, "cannot decrement value-initialized string_view iterator");
		_IDL_VERIFY(_Myoff != 0, "cannot decrement string_view iterator before begin");
		--_Myoff;
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		--_Myptr;
#endif /* _ITERATOR_DEBUG_LEVEL */
		return (*this);
	}

	constexpr _String_view_iterator operator--(int) _NOEXCEPT
	{	// postdecrement
		_String_view_iterator _Tmp{ *this };
		--*this;
		return (_Tmp);
	}

	constexpr _String_view_iterator& operator+=(const difference_type _Off) _NOEXCEPT
	{	// increment by integer
#if _ITERATOR_DEBUG_LEVEL >= 1
		if (_Off != 0)
		{
			_IDL_VERIFY(_Mydata, "cannot seek value-initialized string_view iterator");
		}

		if (_Off < 0)
		{
#pragma warning(suppress: 4146)	// unary minus operator applied to unsigned type, result still unsigned
			_IDL_VERIFY(_Myoff >= -static_cast<size_t>(_Off),
				"cannot seek string_view iterator before begin");
		}

		if (_Off > 0)
		{
			_IDL_VERIFY(_Mysize - _Myoff >= static_cast<size_t>(_Off),
				"cannot seek string_view iterator after end");
		}

		_Myoff += _Off;
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		_Myptr += _Off;
#endif /* _ITERATOR_DEBUG_LEVEL */

		return (*this);
	}

	constexpr _String_view_iterator operator+(const difference_type _Off) const _NOEXCEPT
	{	// return this + integer
		_String_view_iterator _Tmp{ *this };
		_Tmp += _Off;
		return (_Tmp);
	}

	constexpr _String_view_iterator& operator-=(const difference_type _Off) _NOEXCEPT
	{	// decrement by integer
#if _ITERATOR_DEBUG_LEVEL >= 1
		if (_Off != 0)
		{
			_IDL_VERIFY(_Mydata, "cannot seek value-initialized string_view iterator");
		}

		if (_Off > 0)
		{
			_IDL_VERIFY(_Myoff >= static_cast<size_t>(_Off),
				"cannot seek string_view iterator before begin");
		}

		if (_Off < 0)
		{
#pragma warning(suppress: 4146)	// unary minus operator applied to unsigned type, result still unsigned
			_IDL_VERIFY(_Mysize - _Myoff >= -static_cast<size_t>(_Off),
				"cannot seek string_view iterator after end");
		}

		_Myoff -= _Off;
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		_Myptr -= _Off;
#endif /* _ITERATOR_DEBUG_LEVEL */

		return (*this);
	}

	constexpr _String_view_iterator operator-(const difference_type _Off) const _NOEXCEPT
	{	// return this - integer
		_String_view_iterator _Tmp{ *this };
		_Tmp -= _Off;
		return (_Tmp);
	}

	constexpr difference_type operator-(const _String_view_iterator& _Right) const _NOEXCEPT
	{	// return difference of iterators
#if _ITERATOR_DEBUG_LEVEL >= 1
		_IDL_VERIFY(_Mydata == _Right._Mydata && _Mysize == _Right._Mysize,
			"cannot subtract incompatible string_view iterators");
		return (_Myoff - _Right._Myoff);
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		return (_Myptr - _Right._Myptr);
#endif /* _ITERATOR_DEBUG_LEVEL */
	}

	constexpr reference operator[](const difference_type _Off) const _NOEXCEPT
	{	// subscript
		return (*(*this + _Off));
	}

	constexpr bool operator==(const _String_view_iterator& _Right) const _NOEXCEPT
	{	// test for iterator equality
#if _ITERATOR_DEBUG_LEVEL >= 1
		_IDL_VERIFY(_Mydata == _Right._Mydata && _Mysize == _Right._Mysize,
			"cannot compare incompatible string_view iterators for equality");
		return (_Myoff == _Right._Myoff);
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		return (_Myptr == _Right._Myptr);
#endif /* _ITERATOR_DEBUG_LEVEL */
	}

	constexpr bool operator!=(const _String_view_iterator& _Right) const _NOEXCEPT
	{	// test for iterator inequality
		return (!(*this == _Right));
	}

	constexpr bool operator<(const _String_view_iterator& _Right) const _NOEXCEPT
	{	// test if this < _Right
#if _ITERATOR_DEBUG_LEVEL >= 1
		_IDL_VERIFY(_Mydata == _Right._Mydata && _Mysize == _Right._Mysize,
			"cannot compare incompatible string_view iterators");
		return (_Myoff < _Right._Myoff);
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		return (_Myptr < _Right._Myptr);
#endif /* _ITERATOR_DEBUG_LEVEL */
	}

	constexpr bool operator>(const _String_view_iterator& _Right) const _NOEXCEPT
	{	// test if this > _Right
		return (_Right < *this);
	}

	constexpr bool operator<=(const _String_view_iterator& _Right) const _NOEXCEPT
	{	// test if this <= _Right
		return (!(_Right < *this));
	}

	constexpr bool operator>=(const _String_view_iterator& _Right) const _NOEXCEPT
	{	// test if this >= _Right
		return (!(*this < _Right));
	}

private:
#if _ITERATOR_DEBUG_LEVEL >= 1
	pointer _Mydata;
	size_t _Mysize;
	size_t _Myoff;
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
	pointer _Myptr;
#endif /* _ITERATOR_DEBUG_LEVEL */
};

template<class _Traits>
constexpr _String_view_iterator<_Traits> operator+(
	const typename _String_view_iterator<_Traits>::difference_type _Off,
	_String_view_iterator<_Traits> _Right) _NOEXCEPT
{	// return integer + _Right
	_Right += _Off;
	return (_Right);
}

template<class _Traits>
constexpr _String_view_iterator<_Traits>& _Rechecked(_String_view_iterator<_Traits>& _Iter,
	const typename _String_view_iterator<_Traits>::_Unchecked_type _Right) _NOEXCEPT
{	// reset from unchecked iterator
#if _ITERATOR_DEBUG_LEVEL >= 1
	_Iter._Myoff = _Right - _Iter._Mydata;
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
	_Iter._Myptr = _Right;
#endif /* _ITERATOR_DEBUG_LEVEL */
	return (_Iter);
}

template<class _Traits>
constexpr typename _String_view_iterator<_Traits>::_Unchecked_type _Unchecked(
	const _String_view_iterator<_Traits> _Iter) _NOEXCEPT
{	// convert to unchecked
#if _ITERATOR_DEBUG_LEVEL >= 1
	return (_Iter._Mydata + _Iter._Myoff);
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
	return (_Iter._Myptr);
#endif /* _ITERATOR_DEBUG_LEVEL */
}


// CLASS TEMPLATE basic_string_view
template<class _Elem,
	class _Traits>
	class basic_string_view
{	// wrapper for any kind of contiguous character buffer
public:
	static_assert(is_same_v<_Elem, typename _Traits::char_type>, "Bad char_traits for basic_string_view; "
		"N4659 24.4.2 [string.view.template]/1 \"the type traits::char_type shall name the same type as charT.\"");

	using traits_type = _Traits;
	using value_type = _Elem;
	using pointer = _Elem * ;
	using const_pointer = const _Elem *;
	using reference = _Elem & ;
	using const_reference = const _Elem&;
	using const_iterator = _String_view_iterator<_Traits>;
	using iterator = const_iterator;
	using const_reverse_iterator = _STD reverse_iterator<const_iterator>;
	using reverse_iterator = const_reverse_iterator;
	using size_type = size_t;
	using difference_type = ptrdiff_t;

	static constexpr auto npos{ static_cast<size_type>(-1) };

	constexpr basic_string_view() _NOEXCEPT
		: _Mydata(),
		_Mysize(0)
	{	// construct empty basic_string_view
	}

	constexpr basic_string_view(const basic_string_view&) _NOEXCEPT = default;
	constexpr basic_string_view& operator=(const basic_string_view&) _NOEXCEPT = default;

	/* implicit */ constexpr basic_string_view(_In_z_ const const_pointer _Ntcts) _NOEXCEPT // strengthened
		: _Mydata(_Ntcts),
		_Mysize(_Traits::length(_Ntcts))
	{	// construct basic_string_view around a null-terminated character-type sequence
	}

	constexpr basic_string_view(_In_reads_(_Count) const const_pointer _Cts, const size_type _Count)
		_NOEXCEPT // strengthened
		: _Mydata(_Cts),
		_Mysize(_Count)
	{	// construct basic_string_view around a character-type sequence with explicit size
		_IDL_VERIFY(_Count == 0 || _Cts, "non-zero size null string_view");
	}

	constexpr const_iterator begin() const _NOEXCEPT
	{	// get the beginning of the range
#if _ITERATOR_DEBUG_LEVEL >= 1
		return (const_iterator(_Mydata, _Mysize, 0));
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		return (const_iterator(_Mydata));
#endif /* _ITERATOR_DEBUG_LEVEL */
	}

	constexpr const_iterator end() const _NOEXCEPT
	{	// get the end of the range
#if _ITERATOR_DEBUG_LEVEL >= 1
		return (const_iterator(_Mydata, _Mysize, _Mysize));
#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
		return (const_iterator(_Mydata + _Mysize));
#endif /* _ITERATOR_DEBUG_LEVEL */
	}

	constexpr const_iterator cbegin() const _NOEXCEPT
	{	// get the beginning of the range
		return (begin());
	}

	constexpr const_iterator cend() const _NOEXCEPT
	{	// get the end of the range
		return (end());
	}

	constexpr const_reverse_iterator rbegin() const _NOEXCEPT
	{	// get the beginning of the reversed range
		return (const_reverse_iterator{ end() });
	}

	constexpr const_reverse_iterator rend() const _NOEXCEPT
	{	// get the end of the reversed range
		return (const_reverse_iterator{ begin() });
	}

	constexpr const_reverse_iterator crbegin() const _NOEXCEPT
	{	// get the beginning of the reversed range
		return (rbegin());
	}

	constexpr const_reverse_iterator crend() const _NOEXCEPT
	{	// get the end of the reversed range
		return (rend());
	}

	constexpr const_pointer _Unchecked_begin() const _NOEXCEPT
	{	// get pointer to beginning of the range
		return (_Mydata);
	}

	constexpr const_pointer _Unchecked_end() const _NOEXCEPT
	{	// get pointer to end of the range
		return (_Mydata + _Mysize);
	}

	constexpr size_type size() const _NOEXCEPT
	{	// get the size of this basic_string_view
		return (_Mysize);
	}

	constexpr size_type length() const _NOEXCEPT
	{	// get the size of this basic_string_view
		return (_Mysize);
	}

	constexpr bool empty() const _NOEXCEPT
	{	// check whether this basic_string_view is empty
		return (_Mysize == 0);
	}

	constexpr const_pointer data() const _NOEXCEPT
	{	// get the base pointer of this basic_string_view
		return (_Mydata);
	}

	constexpr size_type max_size() const _NOEXCEPT
	{	// get the maximum possible size
		// bound to PTRDIFF_MAX to make end() - begin() well defined (also makes room for npos)
		// bound to static_cast<size_t>(-1) / sizeof(_Elem) by address space limits
		return (_Min_value(static_cast<size_t>(PTRDIFF_MAX), static_cast<size_t>(-1) / sizeof(_Elem)));
	}

	constexpr const_reference operator[](const size_type _Off) const _NOEXCEPT // strengthened
	{	// get character at offset; assume offset is in range
		_IDL_VERIFY(_Off < _Mysize, "string_view subscript out of range");
		return (_Mydata[_Off]);
	}

	constexpr const_reference at(const size_type _Off) const
	{	// get the character at _Off or throw if that is out of range
		_Check_offset_exclusive(_Off);
		return (_Mydata[_Off]);
	}

	constexpr const_reference front() const _NOEXCEPT // strengthened
	{	// returns a reference to the first character in *this
		_IDL_VERIFY(_Mysize != 0, "cannot call front on empty string_view");
		return (_Mydata[0]);
	}

	constexpr const_reference back() const _NOEXCEPT // strengthened
	{	// returns a reference to the last character in *this
		_IDL_VERIFY(_Mysize != 0, "cannot call back on empty string_view");
		return (_Mydata[_Mysize - 1]);
	}

	constexpr void remove_prefix(const size_type _Count) _NOEXCEPT // strengthened
	{	// chop off the beginning
		_IDL_VERIFY(_Mysize >= _Count, "cannot remove prefix longer than total size");
		_Mydata += _Count;
		_Mysize -= _Count;
	}

	constexpr void remove_suffix(const size_type _Count) _NOEXCEPT // strengthened
	{	// chop off the end
		_IDL_VERIFY(_Mysize >= _Count, "cannot remove suffix longer than total size");
		_Mysize -= _Count;
	}

	constexpr void swap(basic_string_view& _Other) _NOEXCEPT
	{	// swap contents
		const basic_string_view _Tmp{ _Other };	// note: std::swap is not constexpr
		_Other = *this;
		*this = _Tmp;
	}

	_SCL_INSECURE_DEPRECATE_FN(basic_string_view::copy)
		constexpr size_type copy(_Out_writes_(_Count) _Elem * const _Ptr, size_type _Count,
			const size_type _Off = 0) const
	{	// copy [_Off, _Off + Count) to [_Ptr, _Ptr + _Count)
		_Check_offset(_Off);
		_Count = _Clamp_suffix_size(_Off, _Count);
		_Traits::copy(_Ptr, _Mydata + _Off, _Count);
		return (_Count);
	}

	_Pre_satisfies_(_Dest_size >= _Count) constexpr size_type _Copy_s(
		_Out_writes_all_(_Dest_size) _Elem * const _Dest, const size_type _Dest_size,
		size_type _Count, const size_type _Off = 0) const
	{	// copy [_Off, _Off + _Count) to [_Dest, _Dest + _Count)
		_Check_offset(_Off);
		_Count = _Clamp_suffix_size(_Off, _Count);
		_Traits::_Copy_s(_Dest, _Dest_size, _Mydata + _Off, _Count);
		return (_Count);
	}

	constexpr basic_string_view substr(const size_type _Off = 0, size_type _Count = npos) const
	{	// return a new basic_string_view moved forward by _Off and trimmed to _Count elements
		_Check_offset(_Off);
		_Count = _Clamp_suffix_size(_Off, _Count);
		return (basic_string_view(_Mydata + _Off, _Count));
	}

	constexpr bool _Equal(const basic_string_view _Right) const _NOEXCEPT
	{	// test if *this and _Right are equal
		return (_Traits_equal<_Traits>(_Mydata, _Mysize, _Right._Mydata, _Right._Mysize));
	}

	constexpr int compare(const basic_string_view _Right) const _NOEXCEPT
	{	// compare [0, _Mysize) with _Right
		return (_Traits_compare<_Traits>(_Mydata, _Mysize, _Right._Mydata, _Right._Mysize));
	}

	constexpr int compare(const size_type _Off, const size_type _N0, const basic_string_view _Right) const
	{	// compare [_Off, _Off + _N0) with _Right
		return (substr(_Off, _N0).compare(_Right));
	}

	constexpr int compare(const size_type _Off, const size_type _N0,
		const basic_string_view _Right, const size_type _Roff, const size_type _Count) const
	{	// compare [_Off, _Off + _N0) with _Right [_Roff, _Roff + _Count)
		return (substr(_Off, _N0).compare(_Right.substr(_Roff, _Count)));
	}

	constexpr int compare(_In_z_ const _Elem * const _Ptr) const
	{	// compare [0, _Mysize) with [_Ptr, <null>)
		return (compare(basic_string_view(_Ptr)));
	}

	constexpr int compare(const size_type _Off, const size_type _N0,
		_In_z_ const _Elem * const _Ptr) const
	{	// compare [_Off, _Off + _N0) with [_Ptr, <null>)
		return (substr(_Off, _N0).compare(basic_string_view(_Ptr)));
	}

	constexpr int compare(const size_type _Off, const size_type _N0,
		_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Count) const
	{	// compare [_Off, _Off + _N0) with [_Ptr, _Ptr + _Count)
		return (substr(_Off, _N0).compare(basic_string_view(_Ptr, _Count)));
	}

	constexpr size_type find(const basic_string_view _Right, const size_type _Off = 0) const _NOEXCEPT
	{	// look for _Right beginning at or after _Off
		return (_Traits_find<_Traits>(_Mydata, _Mysize, _Off, _Right._Mydata, _Right._Mysize));
	}

	constexpr size_type find(const _Elem _Ch, const size_type _Off = 0) const _NOEXCEPT
	{	// look for _Ch at or after _Off
		return (_Traits_find_ch<_Traits>(_Mydata, _Mysize, _Off, _Ch));
	}

	constexpr size_type find(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off,
		const size_type _Count) const _NOEXCEPT // strengthened
	{	// look for [_Ptr, _Ptr + _Count) beginning at or after _Off
		return (_Traits_find<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Count));
	}

	constexpr size_type find(_In_z_ const _Elem * const _Ptr, const size_type _Off = 0) const
		_NOEXCEPT // strengthened
	{	// look for [_Ptr, <null>) beginning at or after _Off
		return (_Traits_find<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Traits::length(_Ptr)));
	}

	constexpr size_type rfind(const basic_string_view _Right, const size_type _Off = npos) const _NOEXCEPT
	{	// look for _Right beginning before _Off
		return (_Traits_rfind<_Traits>(_Mydata, _Mysize, _Off, _Right._Mydata, _Right._Mysize));
	}

	constexpr size_type rfind(const _Elem _Ch, const size_type _Off = npos) const _NOEXCEPT
	{	// look for _Ch before _Off
		return (_Traits_rfind_ch<_Traits>(_Mydata, _Mysize, _Off, _Ch));
	}

	constexpr size_type rfind(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off,
		const size_type _Count) const _NOEXCEPT // strengthened
	{	// look for [_Ptr, _Ptr + _Count) beginning before _Off
		return (_Traits_rfind<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Count));
	}

	constexpr size_type rfind(_In_z_ const _Elem * const _Ptr, const size_type _Off = npos) const
		_NOEXCEPT // strengthened
	{	// look for [_Ptr, <null>) beginning before _Off
		return (_Traits_rfind<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Traits::length(_Ptr)));
	}

	constexpr size_type find_first_of(const basic_string_view _Right, const size_type _Off = 0) const _NOEXCEPT
	{	// look for one of _Right at or after _Off
		return (_Traits_find_first_of<_Traits>(_Mydata, _Mysize, _Off, _Right._Mydata, _Right._Mysize));
	}

	constexpr size_type find_first_of(const _Elem _Ch, const size_type _Off = 0) const _NOEXCEPT
	{	// look for _Ch at or after _Off
		return (_Traits_find_ch<_Traits>(_Mydata, _Mysize, _Off, _Ch));
	}

	constexpr size_type find_first_of(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off,
		const size_type _Count) const _NOEXCEPT // strengthened
	{	// look for one of [_Ptr, _Ptr + _Count) at or after _Off
		return (_Traits_find_first_of<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Count));
	}

	constexpr size_type find_first_of(_In_z_ const _Elem * const _Ptr,
		const size_type _Off = 0) const _NOEXCEPT // strengthened
	{	// look for one of [_Ptr, <null>) at or after _Off
		return (_Traits_find_first_of<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Traits::length(_Ptr)));
	}

	constexpr size_type find_last_of(const basic_string_view _Right, const size_type _Off = npos)
		const _NOEXCEPT
	{	// look for one of _Right before _Off
		return (_Traits_find_last_of<_Traits>(_Mydata, _Mysize, _Off, _Right._Mydata, _Right._Mysize));
	}

	constexpr size_type find_last_of(const _Elem _Ch, const size_type _Off = npos) const _NOEXCEPT
	{	// look for _Ch before _Off
		return (_Traits_rfind_ch<_Traits>(_Mydata, _Mysize, _Off, _Ch));
	}

	constexpr size_type find_last_of(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off,
		const size_type _Count) const _NOEXCEPT // strengthened
	{	// look for one of [_Ptr, _Ptr + _Count) before _Off
		return (_Traits_find_last_of<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Count));
	}

	constexpr size_type find_last_of(_In_z_ const _Elem * const _Ptr, const size_type _Off = npos) const
		_NOEXCEPT // strengthened
	{	// look for one of [_Ptr, <null>) before _Off
		return (_Traits_find_last_of<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Traits::length(_Ptr)));
	}

	constexpr size_type find_first_not_of(const basic_string_view _Right, const size_type _Off = 0) const _NOEXCEPT
	{	// look for none of _Right at or after _Off
		return (_Traits_find_first_not_of<_Traits>(_Mydata, _Mysize, _Off, _Right._Mydata, _Right._Mysize));
	}

	constexpr size_type find_first_not_of(const _Elem _Ch, const size_type _Off = 0) const _NOEXCEPT
	{	// look for any value other than _Ch at or after _Off
		return (_Traits_find_not_ch<_Traits>(_Mydata, _Mysize, _Off, _Ch));
	}

	constexpr size_type find_first_not_of(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off,
		const size_type _Count) const _NOEXCEPT // strengthened
	{	// look for none of [_Ptr, _Ptr + _Count) at or after _Off
		return (_Traits_find_first_not_of<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Count));
	}

	constexpr size_type find_first_not_of(_In_z_ const _Elem * const _Ptr, const size_type _Off = 0) const
		_NOEXCEPT // strengthened
	{	// look for none of [_Ptr, <null>) at or after _Off
		return (_Traits_find_first_not_of<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Traits::length(_Ptr)));
	}

	constexpr size_type find_last_not_of(const basic_string_view _Right, const size_type _Off = npos) const _NOEXCEPT
	{	// look for none of _Right before _Off
		return (_Traits_find_last_not_of<_Traits>(_Mydata, _Mysize, _Off, _Right._Mydata, _Right._Mysize));
	}

	constexpr size_type find_last_not_of(const _Elem _Ch, const size_type _Off = npos) const _NOEXCEPT
	{	// look for any value other than _Ch before _Off
		return (_Traits_rfind_not_ch<_Traits>(_Mydata, _Mysize, _Off, _Ch));
	}

	constexpr size_type find_last_not_of(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off,
		const size_type _Count) const _NOEXCEPT // strengthened
	{	// look for none of [_Ptr, _Ptr + _Count) before _Off
		return (_Traits_find_last_not_of<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Count));
	}

	constexpr size_type find_last_not_of(_In_z_ const _Elem * const _Ptr, const size_type _Off = npos) const
		_NOEXCEPT // strengthened
	{	// look for none of [_Ptr, <null>) before _Off
		return (_Traits_find_last_not_of<_Traits>(_Mydata, _Mysize, _Off, _Ptr, _Traits::length(_Ptr)));
	}

private:
	constexpr void _Check_offset(const size_type _Off) const
	{	// checks whether _Off is in the bounds of [0, size()]
		if (_Mysize < _Off)
		{
			_Xran();
		}
	}

	constexpr void _Check_offset_exclusive(const size_type _Off) const
	{	// checks whether _Off is in the bounds of [0, size())
		if (_Mysize <= _Off)
		{
			_Xran();
		}
	}

	constexpr size_type _Clamp_suffix_size(const size_type _Off, const size_type _Size) const _NOEXCEPT
	{	// trims _Size to the longest it can be assuming a string at/after _Off
		return (_Min_value(_Size, _Mysize - _Off));
	}

	[[noreturn]] static void _Xran()
	{	// report an out_of_range error
		_Xout_of_range("invalid string_view position");
	}

	const_pointer _Mydata;
	size_type _Mysize;
};


// FUNCTION TEMPLATES operator== FOR basic_string_view
template<class _Elem,
	class _Traits>
	constexpr bool operator==(const basic_string_view<_Elem, _Traits> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// compare basic_string_view instances for equality
	return (_Lhs._Equal(_Rhs));
}

template<class _Elem,
	class _Traits,
	int = 1> // TRANSITION, VSO#409326
	constexpr bool operator==(const _Identity_t<basic_string_view<_Elem, _Traits>> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// compare objects convertible to basic_string_view instances for equality
	return (_Lhs._Equal(_Rhs));
}

template<class _Elem,
	class _Traits,
	int = 2> // TRANSITION, VSO#409326
	constexpr bool operator==(const basic_string_view<_Elem, _Traits> _Lhs,
		const _Identity_t<basic_string_view<_Elem, _Traits>> _Rhs) _NOEXCEPT
{	// compare objects convertible to basic_string_view instances for equality
	return (_Lhs._Equal(_Rhs));
}


// FUNCTION TEMPLATES operator!= FOR basic_string_view
template<class _Elem,
	class _Traits>
	constexpr bool operator!=(const basic_string_view<_Elem, _Traits> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// compare basic_string_view instances for inequality
	return (!_Lhs._Equal(_Rhs));
}

template<class _Elem,
	class _Traits,
	int = 1> // TRANSITION, VSO#409326
	constexpr bool operator!=(const _Identity_t<basic_string_view<_Elem, _Traits>> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// compare objects convertible to basic_string_view instances for inequality
	return (!_Lhs._Equal(_Rhs));
}

template<class _Elem,
	class _Traits,
	int = 2> // TRANSITION, VSO#409326
	constexpr bool operator!=(const basic_string_view<_Elem, _Traits> _Lhs,
		const _Identity_t<basic_string_view<_Elem, _Traits>> _Rhs) _NOEXCEPT
{	// compare objects convertible to basic_string_view instances for inequality
	return (!_Lhs._Equal(_Rhs));
}


// FUNCTION TEMPLATES operator< FOR basic_string_view
template<class _Elem,
	class _Traits>
	constexpr bool operator<(const basic_string_view<_Elem, _Traits> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// less-than compare basic_string_view instances
	return (_Lhs.compare(_Rhs) < 0);
}

template<class _Elem,
	class _Traits,
	int = 1> // TRANSITION, VSO#409326
	constexpr bool operator<(const _Identity_t<basic_string_view<_Elem, _Traits>> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// less-than compare objects convertible to basic_string_view instances
	return (_Lhs.compare(_Rhs) < 0);
}

template<class _Elem,
	class _Traits,
	int = 2> // TRANSITION, VSO#409326
	constexpr bool operator<(const basic_string_view<_Elem, _Traits> _Lhs,
		const _Identity_t<basic_string_view<_Elem, _Traits>> _Rhs) _NOEXCEPT
{	// less-than compare objects convertible to basic_string_view instances
	return (_Lhs.compare(_Rhs) < 0);
}


// FUNCTION TEMPLATES operator> FOR basic_string_view
template<class _Elem,
	class _Traits>
	constexpr bool operator>(const basic_string_view<_Elem, _Traits> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// greater-than compare basic_string_view instances
	return (_Lhs.compare(_Rhs) > 0);
}

template<class _Elem,
	class _Traits,
	int = 1> // TRANSITION, VSO#409326
	constexpr bool operator>(const _Identity_t<basic_string_view<_Elem, _Traits>> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// greater-than compare objects convertible to basic_string_view instances
	return (_Lhs.compare(_Rhs) > 0);
}

template<class _Elem,
	class _Traits,
	int = 2> // TRANSITION, VSO#409326
	constexpr bool operator>(const basic_string_view<_Elem, _Traits> _Lhs,
		const _Identity_t<basic_string_view<_Elem, _Traits>> _Rhs) _NOEXCEPT
{	// greater-than compare objects convertible to basic_string_view instances
	return (_Lhs.compare(_Rhs) > 0);
}


// FUNCTION TEMPLATES operator<= FOR basic_string_view
template<class _Elem,
	class _Traits>
	constexpr bool operator<=(const basic_string_view<_Elem, _Traits> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// less-than-or-equal compare basic_string_view instances
	return (_Lhs.compare(_Rhs) <= 0);
}

template<class _Elem,
	class _Traits,
	int = 1> // TRANSITION, VSO#409326
	constexpr bool operator<=(const _Identity_t<basic_string_view<_Elem, _Traits>> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// less-than-or-equal compare objects convertible to basic_string_view instances
	return (_Lhs.compare(_Rhs) <= 0);
}

template<class _Elem,
	class _Traits,
	int = 2> // TRANSITION, VSO#409326
	constexpr bool operator<=(const basic_string_view<_Elem, _Traits> _Lhs,
		const _Identity_t<basic_string_view<_Elem, _Traits>> _Rhs) _NOEXCEPT
{	// less-than-or-equal compare objects convertible to basic_string_view instances
	return (_Lhs.compare(_Rhs) <= 0);
}


// FUNCTION TEMPLATES operator>= FOR basic_string_view
template<class _Elem,
	class _Traits>
	constexpr bool operator>=(const basic_string_view<_Elem, _Traits> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// greater-than-or-equal compare basic_string_view instances
	return (_Lhs.compare(_Rhs) >= 0);
}

template<class _Elem,
	class _Traits,
	int = 1> // TRANSITION, VSO#409326
	constexpr bool operator>=(const _Identity_t<basic_string_view<_Elem, _Traits>> _Lhs,
		const basic_string_view<_Elem, _Traits> _Rhs) _NOEXCEPT
{	// greater-than-or-equal compare objects convertible to basic_string_view instances
	return (_Lhs.compare(_Rhs) >= 0);
}

template<class _Elem,
	class _Traits,
	int = 2> // TRANSITION, VSO#409326
	constexpr bool operator>=(const basic_string_view<_Elem, _Traits> _Lhs,
		const _Identity_t<basic_string_view<_Elem, _Traits>> _Rhs) _NOEXCEPT
{	// greater-than-or-equal compare objects convertible to basic_string_view instances
	return (_Lhs.compare(_Rhs) >= 0);
}


// TYPEDEFS FOR basic_string_view
using string_view = basic_string_view<char>;
using u16string_view = basic_string_view<char16_t>;
using u32string_view = basic_string_view<char32_t>;
using wstring_view = basic_string_view<wchar_t>;


// STRUCT TEMPLATE SPECIALIZATION hash FOR basic_string_view
template<class _Elem,
	class _Traits>
	struct hash<basic_string_view<_Elem, _Traits>>
{	// hash functor for basic_string_view
	_CXX17_DEPRECATE_ADAPTOR_TYPEDEFS typedef basic_string_view<_Elem, _Traits> argument_type;
	_CXX17_DEPRECATE_ADAPTOR_TYPEDEFS typedef size_t result_type;

	size_t operator()(const basic_string_view<_Elem, _Traits> _Keyval) const _NOEXCEPT
	{	// hash _Keyval to size_t value by pseudorandomizing transform
		return (_Hash_array_representation(_Keyval.data(), _Keyval.size()));
	}
};
#endif /* _HAS_CXX17 */

// CLASS TEMPLATE _String_const_iterator
template<class _Mystr>
class _String_const_iterator
	: public _Iterator_base
{	// iterator for immutable string
public:
	using iterator_category = random_access_iterator_tag;

	using value_type = typename _Mystr::value_type;
	using difference_type = typename _Mystr::difference_type;
	using pointer = typename _Mystr::const_pointer;
	using reference = const value_type&;

	_String_const_iterator()
		: _Ptr()
	{	// construct with null pointer
	}

	_String_const_iterator(pointer _Parg, const _Container_base *_Pstring)
		: _Ptr(_Parg)
	{	// construct with pointer _Parg
		this->_Adopt(_Pstring);
	}

	using _Unchecked_type = pointer;

	reference operator*() const
	{	// return designated object
#if _ITERATOR_DEBUG_LEVEL >= 1
		_IDL_VERIFY(_Ptr, "cannot dereference value-initialized string iterator");
		const auto _Mycont = static_cast<const _Mystr *>(this->_Getcont());
		_IDL_VERIFY(_Mycont, "cannot dereference string iterator because the iterator was"
			" invalidated (e.g. reallocation occurred, or the string was destroyed)");
		const auto _Contptr = _Mycont->_Myptr();
		const auto _Rawptr = _Unfancy(_Ptr);
		_IDL_VERIFY(_Contptr <= _Rawptr && _Rawptr < _Contptr + _Mycont->_Mysize,
			"cannot dereference string iterator because it is out of range (e.g. an end iterator)");
#endif /* _ITERATOR_DEBUG_LEVEL >= 1 */

		_Analysis_assume_(_Ptr);
		return (*_Ptr);
	}

	pointer operator->() const
	{	// return pointer to class object
		return (pointer_traits<pointer>::pointer_to(**this));
	}

	_String_const_iterator& operator++()
	{	// preincrement
#if _ITERATOR_DEBUG_LEVEL >= 1
		_IDL_VERIFY(_Ptr, "cannot increment value-initialized string iterator");
		const auto _Mycont = static_cast<const _Mystr *>(this->_Getcont());
		_IDL_VERIFY(_Mycont, "cannot increment string iterator because the iterator was"
			" invalidated (e.g. reallocation occurred, or the string was destroyed)");
		_IDL_VERIFY(_Unfancy(_Ptr) < _Mycont->_Myptr() + _Mycont->_Mysize,
			"cannot increment string iterator past end");
#endif /* _ITERATOR_DEBUG_LEVEL >= 1 */

		++_Ptr;
		return (*this);
	}

	_String_const_iterator operator++(int)
	{	// postincrement
		_String_const_iterator _Tmp = *this;
		++*this;
		return (_Tmp);
	}

	_String_const_iterator& operator--()
	{	// predecrement
#if _ITERATOR_DEBUG_LEVEL >= 1
		_IDL_VERIFY(_Ptr, "cannot decrement value-initialized string iterator");
		const auto _Mycont = static_cast<const _Mystr *>(this->_Getcont());
		_IDL_VERIFY(_Mycont, "cannot decrement string iterator because the iterator was"
			" invalidated (e.g. reallocation occurred, or the string was destroyed)");
		_IDL_VERIFY(_Mycont->_Myptr() < _Unfancy(_Ptr), "cannot decrement string iterator before begin");
#endif /* _ITERATOR_DEBUG_LEVEL >= 1 */

		--_Ptr;
		return (*this);
	}

	_String_const_iterator operator--(int)
	{	// postdecrement
		_String_const_iterator _Tmp = *this;
		--*this;
		return (_Tmp);
	}

	_String_const_iterator& operator+=(const difference_type _Off)
	{	// increment by integer
#if _ITERATOR_DEBUG_LEVEL >= 1
		if (_Off != 0)
		{
			_IDL_VERIFY(_Ptr, "cannot seek value-initialized string iterator");
			const auto _Mycont = static_cast<const _Mystr *>(this->_Getcont());
			_IDL_VERIFY(_Mycont != 0, "cannot seek string iterator because the iterator was"
				" invalidated (e.g. reallocation occurred, or the string was destroyed)");
			const auto _Contptr = _Mycont->_Myptr();
			const auto _Rawptr = _Unfancy(_Ptr);
			_IDL_VERIFY(_Contptr <= _Rawptr + _Off, "cannot seek string iterator before begin");
			_IDL_VERIFY(_Rawptr + _Off <= _Contptr + _Mycont->_Mysize,
				"cannot seek string iterator past end");
		}
#endif /* _ITERATOR_DEBUG_LEVEL >= 1 */

		_Ptr += _Off;
		return (*this);
	}

	_String_const_iterator operator+(const difference_type _Off) const
	{	// return this + integer
		_String_const_iterator _Tmp = *this;
		return (_Tmp += _Off);
	}

	_String_const_iterator& operator-=(const difference_type _Off)
	{	// decrement by integer
		return (*this += -_Off);
	}

	_String_const_iterator operator-(const difference_type _Off) const
	{	// return this - integer
		_String_const_iterator _Tmp = *this;
		return (_Tmp -= _Off);
	}

	difference_type operator-(const _String_const_iterator& _Right) const
	{	// return difference of iterators
		_Compat(_Right);
		return (_Ptr - _Right._Ptr);
	}

	reference operator[](const difference_type _Off) const
	{	// subscript
		return (*(*this + _Off));
	}

	bool operator==(const _String_const_iterator& _Right) const
	{	// test for iterator equality
		_Compat(_Right);
		return (_Ptr == _Right._Ptr);
	}

	bool operator!=(const _String_const_iterator& _Right) const
	{	// test for iterator inequality
		return (!(*this == _Right));
	}

	bool operator<(const _String_const_iterator& _Right) const
	{	// test if this < _Right
		_Compat(_Right);
		return (_Ptr < _Right._Ptr);
	}

	bool operator>(const _String_const_iterator& _Right) const
	{	// test if this > _Right
		return (_Right < *this);
	}

	bool operator<=(const _String_const_iterator& _Right) const
	{	// test if this <= _Right
		return (!(_Right < *this));
	}

	bool operator>=(const _String_const_iterator& _Right) const
	{	// test if this >= _Right
		return (!(*this < _Right));
	}

#if _ITERATOR_DEBUG_LEVEL >= 1
	void _Compat(const _String_const_iterator& _Right) const
	{	// test for compatible iterator pair
		_IDL_VERIFY(this->_Getcont() == _Right._Getcont(), "string iterators incompatible (e.g."
			" point to different string instances)");
	}

#else /* ^^^ _ITERATOR_DEBUG_LEVEL >= 1 ^^^ // vvv _ITERATOR_DEBUG_LEVEL == 0 vvv */
	void _Compat(const _String_const_iterator&) const
	{	// test for compatible iterator pair
	}
#endif /* _ITERATOR_DEBUG_LEVEL */

	pointer _Ptr;	// pointer to element in string
};

template<class _Mystr> inline
_String_const_iterator<_Mystr> operator+(
	typename _String_const_iterator<_Mystr>::difference_type _Off,
	_String_const_iterator<_Mystr> _Next)
{	// add offset to iterator
	return (_Next += _Off);
}

template<class _Mystr> inline
_String_const_iterator<_Mystr>& _Rechecked(_String_const_iterator<_Mystr>& _Iter,
	const typename _String_const_iterator<_Mystr>::_Unchecked_type _Right)
{	// reset from unchecked iterator
	_Iter._Ptr = _Right;
	return (_Iter);
}

template<class _Mystr> inline
typename _String_const_iterator<_Mystr>::_Unchecked_type _Unchecked(
	const _String_const_iterator<_Mystr>& _Iter)
{	// make an unchecked iterator
	return (_Iter._Ptr);
}

// CLASS TEMPLATE _String_iterator
template<class _Mystr>
class _String_iterator
	: public _String_const_iterator<_Mystr>
{	// iterator for mutable string
public:
	using _Mybase = _String_const_iterator<_Mystr>;
	using iterator_category = random_access_iterator_tag;

	using value_type = typename _Mystr::value_type;
	using difference_type = typename _Mystr::difference_type;
	using pointer = typename _Mystr::pointer;
	using reference = value_type & ;

	_String_iterator()
	{	// construct with null string pointer
	}

	_String_iterator(pointer _Parg, const _Container_base *_Pstring)
		: _Mybase(_Parg, _Pstring)
	{	// construct with pointer _Parg
	}

	using _Unchecked_type = pointer;

	reference operator*() const
	{	// return designated object
		return ((reference)**(_Mybase *)this);
	}

	pointer operator->() const
	{	// return pointer to class object
		return (pointer_traits<pointer>::pointer_to(**this));
	}

	_String_iterator& operator++()
	{	// preincrement
		++*(_Mybase *)this;
		return (*this);
	}

	_String_iterator operator++(int)
	{	// postincrement
		_String_iterator _Tmp = *this;
		++*this;
		return (_Tmp);
	}

	_String_iterator& operator--()
	{	// predecrement
		--*(_Mybase *)this;
		return (*this);
	}

	_String_iterator operator--(int)
	{	// postdecrement
		_String_iterator _Tmp = *this;
		--*this;
		return (_Tmp);
	}

	_String_iterator& operator+=(const difference_type _Off)
	{	// increment by integer
		*(_Mybase *)this += _Off;
		return (*this);
	}

	_String_iterator operator+(const difference_type _Off) const
	{	// return this + integer
		_String_iterator _Tmp = *this;
		return (_Tmp += _Off);
	}

	_String_iterator& operator-=(const difference_type _Off)
	{	// decrement by integer
		return (*this += -_Off);
	}

	_String_iterator operator-(const difference_type _Off) const
	{	// return this - integer
		_String_iterator _Tmp = *this;
		return (_Tmp -= _Off);
	}

	difference_type operator-(const _Mybase& _Right) const
	{	// return difference of iterators
		return (*(_Mybase *)this - _Right);
	}

	reference operator[](const difference_type _Off) const
	{	// subscript
		return (*(*this + _Off));
	}
};

template<class _Mystr> inline
_String_iterator<_Mystr> operator+(
	typename _String_iterator<_Mystr>::difference_type _Off,
	_String_iterator<_Mystr> _Next)
{	// add offset to iterator
	return (_Next += _Off);
}

template<class _Mystr> inline
_String_iterator<_Mystr>& _Rechecked(_String_iterator<_Mystr>& _Iter,
	const typename _String_iterator<_Mystr>::_Unchecked_type _Right)
{	// reset from unchecked iterator
	_Iter._Ptr = _Right;
	return (_Iter);
}

template<class _Mystr> inline
typename _String_iterator<_Mystr>::_Unchecked_type _Unchecked(
	const _String_iterator<_Mystr>& _Iter)
{	// make an unchecked iterator
	return (_Const_cast(_Iter._Ptr));
}

// basic_string TYPE WRAPPERS
template<class _Value_type,
	class _Size_type,
	class _Difference_type,
	class _Pointer,
	class _Const_pointer,
	class _Reference,
	class _Const_reference>
	struct _String_iter_types
{	// wraps types needed by iterators
	using value_type = _Value_type;
	using size_type = _Size_type;
	using difference_type = _Difference_type;
	using pointer = _Pointer;
	using const_pointer = _Const_pointer;
};

template<class _Ty,
	class _Alloc>
	struct _String_base_types
{	// types needed for a container base
	using _Alty = _Rebind_alloc_t<_Alloc, _Ty>;
	using _Alty_traits = allocator_traits<_Alty>;

	using _Val_types = conditional_t<_Is_simple_alloc_v<_Alty>,
		_Simple_types<_Ty>,
		_String_iter_types<_Ty,
		typename _Alty_traits::size_type,
		typename _Alty_traits::difference_type,
		typename _Alty_traits::pointer,
		typename _Alty_traits::const_pointer,
		_Ty&,
		const _Ty&>>;
};

// CLASS TEMPLATE _String_val
template<class _Val_types>
class _String_val
	: public _Container_base
{	// base class for basic_string to hold data
public:
	using value_type = typename _Val_types::value_type;
	using size_type = typename _Val_types::size_type;
	using difference_type = typename _Val_types::difference_type;
	using pointer = typename _Val_types::pointer;
	using const_pointer = typename _Val_types::const_pointer;
	using reference = value_type & ;
	using const_reference = const value_type&;

	_String_val()
		: _Bx(),
		_Mysize(0),
		_Myres(0)
	{	// initialize values
	}

	enum
	{	// length of internal buffer, [1, 16]
		_BUF_SIZE = 16 / sizeof(value_type) < 1 ? 1
		: 16 / sizeof(value_type)
	};
	enum
	{	// roundup mask for allocated buffers, [0, 15]
		_ALLOC_MASK = sizeof(value_type) <= 1 ? 15
		: sizeof(value_type) <= 2 ? 7
		: sizeof(value_type) <= 4 ? 3
		: sizeof(value_type) <= 8 ? 1 : 0
	};

	value_type *_Myptr()
	{	// determine current pointer to buffer for mutable string
		value_type * _Result = _Bx._Buf;
		if (_Large_string_engaged())
		{
			_Result = _Unfancy(_Bx._Ptr);
		}

		return (_Result);
	}

	const value_type *_Myptr() const
	{	// determine current pointer to buffer for immutable string
		const value_type * _Result = _Bx._Buf;
		if (_Large_string_engaged())
		{
			_Result = _Unfancy(_Bx._Ptr);
		}

		return (_Result);
	}

	bool _Large_string_engaged() const
	{	// returns whether the large string mode (allocated memory) is engaged
		return (_BUF_SIZE <= _Myres);
	}

	void _Check_offset(const size_type _Off) const
	{	// checks whether _Off is in the bounds of [0, this->size()]
		if (_Mysize < _Off)
		{
			_Xran();
		}
	}

	void _Check_offset_exclusive(const size_type _Off) const
	{	// checks whether _Off is in the bounds of [0, this->size())
		if (_Mysize <= _Off)
		{
			_Xran();
		}
	}

	[[noreturn]] static void _Xran()
	{	// report an out_of_range error
		_Xout_of_range("invalid string position");
	}

	size_type _Clamp_suffix_size(const size_type _Off, const size_type _Size) const _NOEXCEPT
	{	// trims _Size to the longest it can be assuming a string at/after _Off
		return (_Min_value(_Size, _Mysize - _Off));
	}

	union _Bxty
	{	// storage for small buffer or pointer to larger one
		_Bxty()
		{	// user-provided, for fancy pointers
		}

		~_Bxty() _NOEXCEPT
		{	// user-provided, for fancy pointers
		}

		value_type _Buf[_BUF_SIZE];
		pointer _Ptr;
		char _Alias[_BUF_SIZE];	// retained for /clr bincompat; unused
	} _Bx;

	size_type _Mysize;	// current length of string
	size_type _Myres;	// current storage reserved for string
};

// CLASS TEMPLATE _String_alloc
template<class _Alloc_types>
class _String_alloc
{	// base class for basic_string to hold allocator
public:
	using _Alty = typename _Alloc_types::_Alty;
	using _Alty_traits = typename _Alloc_types::_Alty_traits;
	using _Alproxy = _Rebind_alloc_t<_Alty, _Container_proxy>;
	using _Alproxy_traits = allocator_traits<_Alproxy>;
	using _Val_types = typename _Alloc_types::_Val_types;
	using _Mydata_t = _String_val<_Val_types>;
	using _Bxty = typename _Mydata_t::_Bxty;

	using value_type = typename _Val_types::value_type;
	using size_type = typename _Val_types::size_type;
	using difference_type = typename _Val_types::difference_type;
	using pointer = typename _Val_types::pointer;
	using const_pointer = typename _Val_types::const_pointer;
	using reference = value_type & ;
	using const_reference = const value_type&;

	using iterator = _String_iterator<_Mydata_t>;
	using const_iterator = _String_const_iterator<_Mydata_t>;

	enum
	{	// length of internal buffer, [1, 16]
		_BUF_SIZE = _Mydata_t::_BUF_SIZE
	};

	enum
	{	// roundup mask for allocated buffers, [0, 15]
		_ALLOC_MASK = _Mydata_t::_ALLOC_MASK
	};

#if _ITERATOR_DEBUG_LEVEL == 0
	_String_alloc()
		: _Mypair(_Zero_then_variadic_args_t())
	{	// default construct allocator
	}

	template<class _Any_alloc,
		class = enable_if_t<!is_same_v<decay_t<_Any_alloc>, _String_alloc>>>
		_String_alloc(_Any_alloc&& _Al)
		: _Mypair(_One_then_variadic_args_t(),
			_STD forward<_Any_alloc>(_Al))
	{	// construct allocator from _Al
	}

	void _Copy_alloc(const _Alty& _Al)
	{	// replace old allocator
		_Pocca(_Getal(), _Al);
	}

	void _Move_alloc(_Alty& _Al)
	{	// replace old allocator
		_Pocma(_Getal(), _Al);
	}

#else /* _ITERATOR_DEBUG_LEVEL == 0 */
	_String_alloc()
		: _Mypair(_Zero_then_variadic_args_t())
	{	// default construct allocator
		_Alloc_proxy();
	}

	template<class _Any_alloc,
		class = enable_if_t<!is_same_v<decay_t<_Any_alloc>, _String_alloc>>>
		_String_alloc(_Any_alloc&& _Al)
		: _Mypair(_One_then_variadic_args_t(),
			_STD forward<_Any_alloc>(_Al))
	{	// construct allocator from _Al
		_Alloc_proxy();
	}

	~_String_alloc() _NOEXCEPT
	{	// destroy the object
		_Free_proxy();
	}

	void _Copy_alloc(const _Alty& _Al)
	{	// replace old allocator
		const bool _Reload = _Alty_traits::propagate_on_container_copy_assignment::value
			&& _Getal() != _Al;

		if (_Reload)
		{
			_Free_proxy();
		}

		_Pocca(_Getal(), _Al);

		if (_Reload)
		{
			_Alloc_proxy();
		}
	}

	void _Move_alloc(_Alty& _Al)
	{	// replace old allocator
		const bool _Reload = _Alty_traits::propagate_on_container_move_assignment::value
			&& _Getal() != _Al;

		if (_Reload)
		{
			_Free_proxy();
		}

		_Pocma(_Getal(), _Al);

		if (_Reload)
		{
			_Alloc_proxy();
		}
	}

	void _Alloc_proxy()
	{	// construct proxy
		_Alproxy _Proxy_allocator(_Getal());
		_Myproxy() = _Unfancy(_Proxy_allocator.allocate(1));
		_Alproxy_traits::construct(_Proxy_allocator, _Myproxy(), _Container_proxy());
		_Myproxy()->_Mycont = _STD addressof(_Get_data());
	}

	void _Free_proxy()
	{	// destroy proxy
		_Alproxy _Proxy_allocator(_Getal());
		_Orphan_all();
		_Alproxy_traits::destroy(_Proxy_allocator, _Myproxy());
		_Deallocate_plain(_Proxy_allocator, _Myproxy());
		_Myproxy() = 0;
	}

	_Iterator_base12 **_Getpfirst() const
	{	// get address of iterator chain
		return (_Get_data()._Getpfirst());
	}

	_Container_proxy * & _Myproxy() _NOEXCEPT
	{	// return reference to _Myproxy
		return (_Get_data()._Myproxy);
	}

	_Container_proxy * const & _Myproxy() const _NOEXCEPT
	{	// return const reference to _Myproxy
		return (_Get_data()._Myproxy);
	}
#endif /* _ITERATOR_DEBUG_LEVEL == 0 */

	void _Orphan_all()
	{	// orphan all iterators
		_Get_data()._Orphan_all();
	}

	void _Swap_all(_String_alloc& _Right)
	{	// swap all iterators
		_Get_data()._Swap_all(_Right._Get_data());
	}

	_Alty& _Getal() _NOEXCEPT
	{	// return reference to allocator
		return (_Mypair._Get_first());
	}

	const _Alty& _Getal() const _NOEXCEPT
	{	// return const reference to allocator
		return (_Mypair._Get_first());
	}

	_Mydata_t& _Get_data() _NOEXCEPT
	{	// return reference to _String_val
		return (_Mypair._Get_second());
	}

	const _Mydata_t& _Get_data() const _NOEXCEPT
	{	// return const reference to _String_val
		return (_Mypair._Get_second());
	}

private:
	_Compressed_pair<_Alty, _Mydata_t> _Mypair;
};


// CLASS TEMPLATE basic_string
template<class _Ty>
constexpr size_t _Size_after_ebco_v
= is_empty_v<_Ty> ? 0 : sizeof(_Ty);	// get _Ty's size after being EBCO'd

template<class _Elem,
	class _Traits = char_traits<_Elem>,
	class _Alloc = allocator<_Elem>>
	class basic_string
	: public _String_alloc<_String_base_types<_Elem, _Alloc>>
{	// null-terminated transparent array of elements
public:
	static_assert(!_ENFORCE_MATCHING_ALLOCATORS || is_same_v<_Elem, typename _Alloc::value_type>,
		_MISMATCHED_ALLOCATOR_MESSAGE("basic_string<T, Traits, Allocator>", "T"));

	static_assert(is_same_v<_Elem, typename _Traits::char_type>,
		"N4659 24.3.2.1 [string.require]/3 requires that the supplied "
		"char_traits character type match the string's character type.");

	using _Mybase = _String_alloc<_String_base_types<_Elem, _Alloc>>;
	using traits_type = _Traits;
	using allocator_type = _Alloc;

	using _Alty = typename _Mybase::_Alty;
	using _Alty_traits = typename _Mybase::_Alty_traits;
	using _Mydata_t = typename _Mybase::_Mydata_t;

	using value_type = typename _Mybase::value_type;
	using size_type = typename _Mybase::size_type;
	using difference_type = typename _Mybase::difference_type;
	using pointer = typename _Mybase::pointer;
	using const_pointer = typename _Mybase::const_pointer;
	using reference = value_type & ;
	using const_reference = const value_type&;

	using iterator = typename _Mybase::iterator;
	using const_iterator = typename _Mybase::const_iterator;

	using reverse_iterator = _STD reverse_iterator<iterator>;
	using const_reverse_iterator = _STD reverse_iterator<const_iterator>;

	// When doing swap / move by memcpy, we are touching:
	//   _String_val::_Bx::_Buf (type is array of _Elem)
	//   _String_val::_Bx::_Ptr (type is pointer)
	//   _String_val::_Mysize   (type is size_type)
	//   _String_val::_Myres    (type is size_type)
	// N4659 24.1 [strings.general]/1 says _Elem must be a non-array POD, so memcpy is safe.
	// We need to ask if pointer is safe to memcpy.
	// size_type must be an unsigned integral type so memcpy is safe.
	// We also need to disable memcpy if the user has supplied _Traits, since
	//   they can observe traits::assign and similar.
	using _Use_memcpy_move = bool_constant<
		_Is_specialization<_Traits, char_traits>::value && is_trivial_v<pointer>>;
	// This offset skips over the _Container_base members, if any
	static constexpr size_t _Memcpy_move_offset = _Size_after_ebco_v<_Container_base>;
	static constexpr size_t _Memcpy_move_size = sizeof(_Mydata_t) - _Memcpy_move_offset;

	template<class _Iter>
	using _Is_elem_cptr = _Disjunction_t<
		is_same<_Iter, const _Elem * const>,
		is_same<_Iter, _Elem * const>,
		is_same<_Iter, const _Elem *>,
		is_same<_Iter, _Elem *>>;

#if _HAS_CXX17
	template<class _StringViewIsh>
	using _Is_string_view_ish = enable_if_t<conjunction_v<
		is_convertible<const _StringViewIsh&, basic_string_view<_Elem, _Traits>>,
		negation<is_convertible<const _StringViewIsh&, const _Elem *>>>>;
#endif /* _HAS_CXX17 */


	basic_string(const basic_string& _Right)
		: _Mybase(_Alty_traits::select_on_container_copy_construction(_Right._Getal()))
	{	// construct by copying _Right
		_Construct_lv_contents(_Right);
	}

	basic_string(const basic_string& _Right, const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct by copying with allocator
		_Construct_lv_contents(_Right);
	}

	basic_string() _NOEXCEPT_COND(is_nothrow_default_constructible_v<_Alty>)
		: _Mybase()
	{	// construct empty string
		_Tidy_init();
	}

	explicit basic_string(const _Alloc& _Al) _NOEXCEPT
		: _Mybase(_Al)
	{	// construct empty string with allocator
		_Tidy_init();
	}

	basic_string(const basic_string& _Right, const size_type _Roff, const _Alloc& _Al = _Alloc())
		: _Mybase(_Al)
	{	// construct from _Right [_Roff, <end>)
		_Tidy_init();
		assign(_Right, _Roff, npos);
	}

	basic_string(const basic_string& _Right, const size_type _Roff, const size_type _Count, const _Alloc& _Al = _Alloc())
		: _Mybase(_Al)
	{	// construct from _Right [_Roff, _Roff + _Count)
		_Tidy_init();
		assign(_Right, _Roff, _Count);
	}

	basic_string(_In_reads_(_Count) const _Elem * const _Ptr, _CRT_GUARDOVERFLOW const size_type _Count)
		: _Mybase()
	{	// construct from [_Ptr, _Ptr + _Count)
		_Tidy_init();
		assign(_Ptr, _Count);
	}

	basic_string(_In_reads_(_Count) const _Elem * const _Ptr, _CRT_GUARDOVERFLOW const size_type _Count,
		const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct from [_Ptr, _Ptr + _Count) with allocator
		_Tidy_init();
		assign(_Ptr, _Count);
	}

	basic_string(_In_z_ const _Elem * const _Ptr)
		: _Mybase()
	{	// construct from [_Ptr, <null>)
		_Tidy_init();
		assign(_Ptr);
	}

	basic_string(_In_z_ const _Elem * const _Ptr, const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct from [_Ptr, <null>) with allocator
		_Tidy_init();
		assign(_Ptr);
	}

	basic_string(_CRT_GUARDOVERFLOW const size_type _Count, const _Elem _Ch)
		: _Mybase()
	{	// construct from _Count * _Ch
		_Tidy_init();
		assign(_Count, _Ch);
	}

	basic_string(_CRT_GUARDOVERFLOW const size_type _Count, const _Elem _Ch, const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct from _Count * _Ch with allocator
		_Tidy_init();
		assign(_Count, _Ch);
	}

	template<class _Iter,
		class = enable_if_t<_Is_iterator_v<_Iter>>>
		basic_string(_Iter _First, _Iter _Last, const _Alloc& _Al = _Alloc())
		: _Mybase(_Al)
	{	// construct from [_First, _Last) with optional allocator
		_DEBUG_RANGE(_First, _Last);
		_Tidy_init();
		_Construct(_Unchecked(_First), _Unchecked(_Last), _Iter_cat_t<_Iter>());
	}

	template<class _Iter>
	void _Construct(_Iter _First, const _Iter _Last, input_iterator_tag)
	{	// initialize from [_First, _Last), input iterators
		_TRY_BEGIN
			for (; _First != _Last; ++_First)
			{
				push_back(static_cast<_Elem>(*_First));
			}

		_CATCH_ALL
			_Tidy_deallocate();
		_RERAISE;
		_CATCH_END
	}

	template<class _Iter>
	void _Construct(const _Iter _First, const _Iter _Last, forward_iterator_tag)
	{	// initialize from [_First, _Last), forward iterators
		const size_type _Count = _Convert_size<size_type>(static_cast<size_t>(_STD distance(_First, _Last)));
		reserve(_Count);
		_Construct(_First, _Last, input_iterator_tag());
	}

	void _Construct(_Elem * const _First, _Elem * const _Last, random_access_iterator_tag)
	{	// initialize from [_First, _Last), pointers
		if (_First != _Last)
		{
			assign(_First, _Convert_size<size_type>(static_cast<size_t>(_Last - _First)));
		}
	}

	void _Construct(const _Elem * const _First, const _Elem * const _Last, random_access_iterator_tag)
	{	// initialize from [_First, _Last), const pointers
		if (_First != _Last)
		{
			assign(_First, _Convert_size<size_type>(static_cast<size_t>(_Last - _First)));
		}
	}

	basic_string(basic_string&& _Right) _NOEXCEPT
		: _Mybase(_STD move(_Right._Getal()))
	{	// construct by moving _Right
		_Assign_rv_contents_with_alloc_always_equal(_STD move(_Right), _Use_memcpy_move{});
	}

	basic_string(basic_string&& _Right, const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct by moving _Right, allocator
		_Assign_rv_contents(_STD move(_Right), typename _Alty_traits::is_always_equal{});
	}

#if _HAS_CXX17
	explicit basic_string(const basic_string_view<_Elem, _Traits> _Right,
		const _Alloc& _Al = _Alloc())
		: basic_string(_Right.data(), _Convert_size<size_type>(_Right.size()), _Al)
	{	// construct from _Right using _Al
	}

	template<class _StringViewIsh,
		class = _Is_string_view_ish<_StringViewIsh>>
		basic_string(const _StringViewIsh& _Right, const size_type _Roff, const size_type _Count,
			const _Alloc& _Al = _Alloc())
		: _Mybase(_Al)
	{	// construct from _Right [_Roff, _Roff + _Count) using _Al
		_Tidy_init();
		assign(_Right, _Roff, _Count);
	}
#endif /* _HAS_CXX17 */

	basic_string& operator=(basic_string&& _Right)
		_NOEXCEPT_COND(_Alty_traits::propagate_on_container_move_assignment::value
			|| _Alty_traits::is_always_equal::value)
	{	// assign by moving _Right
		if (this != _STD addressof(_Right))
		{	// different, assign it
			_Tidy_deallocate();
			this->_Move_alloc(_Right._Getal());
			// tag dispatch to remove unnecessary exception handling codegen in the
			// equal allocators case
			_Assign_rv_contents(_STD move(_Right),
				bool_constant<_Alty_traits::propagate_on_container_move_assignment::value
				|| _Alty_traits::is_always_equal::value>{});
		}

		return (*this);
	}

	basic_string& assign(basic_string&& _Right) _NOEXCEPT_COND(_Alty_traits::propagate_on_container_move_assignment::value
		|| _Alty_traits::is_always_equal::value)
	{	// assign by moving _Right
		*this = _STD move(_Right);
		return (*this);
	}

	void _Assign_rv_contents(basic_string&& _Right, true_type)
	{	// assign either as an rvalue or as an lvalue copy, allocators always equal optimization
		// pre: this != &_Right
		// pre: allocator propagation (POCMA) from _Right, if necessary, is complete
		// pre: *this owns no memory, iterators orphaned (note: _Buf/_Ptr/_Mysize/_Myres may be garbage init)
		_Assign_rv_contents_with_alloc_always_equal(_STD move(_Right), _Use_memcpy_move{});
	}

	void _Assign_rv_contents(basic_string&& _Right, false_type)
	{	// assign either as an rvalue or as an lvalue copy, allocators potentially unequal
		// pre: this != &_Right
		// pre: allocator propagation (POCMA) from _Right, if necessary, is complete
		// pre: *this owns no memory, iterators orphaned (note: _Buf/_Ptr/_Mysize/_Myres may be garbage init)
		if (this->_Getal() == _Right._Getal())
		{
			_Assign_rv_contents_with_alloc_always_equal(_STD move(_Right), _Use_memcpy_move{});
		}
		else
		{
			_Construct_lv_contents(_Right);
		}
	}

	void _Assign_rv_contents_with_alloc_always_equal(basic_string&& _Right, true_type)
	{	// assign by stealing _Right's buffer, memcpy optimization
		// pre: this != &_Right
		// pre: allocator propagation (POCMA) from _Right, if necessary, is complete
		// pre: *this owns no memory, iterators orphaned (note: _Buf/_Ptr/_Mysize/_Myres may be garbage init)
		auto& _Right_data = _Right._Get_data();

#if _ITERATOR_DEBUG_LEVEL != 0
		if (_Right_data._Large_string_engaged())
		{	// take ownership of _Right's iterators along with its buffer
			this->_Swap_all(_Right);
		}
		else
		{
			_Right._Orphan_all();
		}
#endif /* _ITERATOR_DEBUG_LEVEL != 0 */

		const auto _My_data_mem = reinterpret_cast<unsigned char *>(_STD addressof(this->_Get_data()))
			+ _Memcpy_move_offset;
		const auto _Right_data_mem = reinterpret_cast<unsigned char *>(_STD addressof(_Right_data))
			+ _Memcpy_move_offset;
		_CSTD memcpy(_My_data_mem, _Right_data_mem, _Memcpy_move_size);
		_Right._Tidy_init();
	}

	void _Assign_rv_contents_with_alloc_always_equal(basic_string&& _Right, false_type)
	{	// assign by stealing _Right's buffer, general case
		// pre: this != &_Right
		// pre: allocator propagation (POCMA) from _Right, if necessary, is complete
		// pre: *this owns no memory, iterators orphaned (note: _Buf/_Ptr/_Mysize/_Myres may be garbage init)
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		if (_Right_data._Large_string_engaged())
		{	// steal buffer
			_Alty_traits::construct(this->_Getal(), _STD addressof(_My_data._Bx._Ptr), _Right_data._Bx._Ptr);
			_Right_data._Bx._Ptr = pointer();
			this->_Swap_all(_Right);
		}
		else
		{	// copy small string buffer
			_Traits::copy(_My_data._Bx._Buf, _Right_data._Bx._Buf, _Right_data._Mysize + 1);
			_Right._Orphan_all();
		}

		_My_data._Mysize = _Right_data._Mysize;
		_My_data._Myres = _Right_data._Myres;
		_Right._Tidy_init();
	}

	void _Construct_lv_contents(const basic_string& _Right)
	{	// assign by copying data stored in _Right
		// pre: this != &_Right
		// pre: *this owns no memory, iterators orphaned (note: _Buf/_Ptr/_Mysize/_Myres may be garbage init)
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		const size_type _Right_size = _Right_data._Mysize;
		const _Elem * const _Right_ptr = _Right_data._Myptr();
		if (_Right_size < this->_BUF_SIZE)
		{   // stay small, don't allocate
			_Traits::copy(_My_data._Bx._Buf, _Right_ptr, this->_BUF_SIZE);
			_My_data._Mysize = _Right_size;
			_My_data._Myres = this->_BUF_SIZE - 1;
			return;
		}

		auto& _Al = this->_Getal();
		const size_type _New_capacity = _Min_value(_Right_size | this->_ALLOC_MASK, max_size());
		const pointer _New_array = _Al.allocate(_New_capacity + 1); // throws
		_Alty_traits::construct(_Al, _STD addressof(_My_data._Bx._Ptr), _New_array);
		_Traits::copy(_Unfancy(_New_array), _Right_ptr, _Right_size + 1);
		_My_data._Mysize = _Right_size;
		_My_data._Myres = _New_capacity;
	}

	basic_string(initializer_list<_Elem> _Ilist, const _Alloc& _Al = allocator_type())
		: _Mybase(_Al)
	{	// construct from initializer_list
		_Tidy_init();
		assign(_Ilist.begin(), _Ilist.size());
	}

	basic_string& operator=(initializer_list<_Elem> _Ilist)
	{	// assign initializer_list
		return (assign(_Ilist.begin(), _Ilist.size()));
	}

	basic_string& operator+=(initializer_list<_Elem> _Ilist)
	{	// append initializer_list
		return (append(_Ilist.begin(), _Ilist.size()));
	}

	basic_string& assign(initializer_list<_Elem> _Ilist)
	{	// assign initializer_list
		return (assign(_Ilist.begin(), _Ilist.size()));
	}

	basic_string& append(initializer_list<_Elem> _Ilist)
	{	// append initializer_list
		return (append(_Ilist.begin(), _Ilist.size()));
	}

	iterator insert(const const_iterator _Where, const initializer_list<_Elem> _Ilist)
	{	// insert initializer_list
		const size_type _Off = _Where - begin();
		insert(_Off, _Ilist.begin(), _Ilist.size());
		return (begin() + _Off);
	}

	basic_string& replace(const const_iterator _First, const const_iterator _Last, const initializer_list<_Elem> _Ilist)
	{	// replace with initializer_list
		return (replace(_First - begin(), _Last - _First, _Ilist.begin(), _Ilist.size()));
	}

	~basic_string() _NOEXCEPT
	{	// destroy the string
		_Tidy_deallocate();
	}

	static constexpr auto npos{ static_cast<size_type>(-1) };

	basic_string& operator=(const basic_string& _Right)
	{	// assign _Right
		if (this != _STD addressof(_Right))
		{	// different, assign it
#pragma warning(push)
#pragma warning(disable: 4127)	// conditional expression is constant
			if (_Alty_traits::propagate_on_container_copy_assignment::value
				&& this->_Getal() != _Right._Getal())
			{	// change allocator before copying
				_Tidy_deallocate();
			}
#pragma warning(pop)

			this->_Copy_alloc(_Right._Getal());

			auto& _Right_data = _Right._Get_data();
			assign(_Right_data._Myptr(), _Right_data._Mysize);
		}

		return (*this);
	}

#if _HAS_CXX17
	basic_string& operator=(const basic_string_view<_Elem, _Traits> _Right)
	{	// assign _Right
		return (assign(_Right));
	}
#endif /* _HAS_CXX17 */

	basic_string& operator=(_In_z_ const _Elem * const _Ptr)
	{	// assign [_Ptr, <null>)
		return (assign(_Ptr));
	}

	basic_string& operator=(const _Elem _Ch)
	{	// assign {_Ch, _Elem()}
		auto& _My_data = this->_Get_data();
		_My_data._Mysize = 1;
		_Elem * const _Ptr = _My_data._Myptr();
		_Traits::assign(_Ptr[0], _Ch);
		_Traits::assign(_Ptr[1], _Elem());
		return (*this);
	}

	basic_string& operator+=(const basic_string& _Right)
	{	// append _Right
		return (append(_Right));
	}

#if _HAS_CXX17
	basic_string& operator+=(const basic_string_view<_Elem, _Traits> _Right)
	{	// append _Right
		return (append(_Right));
	}
#endif /* _HAS_CXX17 */

	basic_string& operator+=(_In_z_ const _Elem * const _Ptr)
	{	// append [_Ptr, <null>)
		return (append(_Ptr));
	}

	basic_string& operator+=(_Elem _Ch)
	{	// append 1 * _Ch
		push_back(_Ch);
		return (*this);
	}

	basic_string& append(const basic_string& _Right)
	{	// append _Right
		auto& _Right_data = _Right._Get_data();
		return (append(_Right_data._Myptr(), _Right_data._Mysize));
	}

	basic_string& append(const basic_string& _Right, const size_type _Roff, size_type _Count = npos)
	{	// append _Right [_Roff, _Roff + _Count)
		auto& _Right_data = _Right._Get_data();
		_Right_data._Check_offset(_Roff);
		_Count = _Right_data._Clamp_suffix_size(_Roff, _Count);
		return (append(_Right_data._Myptr() + _Roff, _Count));
	}

#if _HAS_CXX17
	basic_string& append(const basic_string_view<_Elem, _Traits> _Right)
	{	// append _Right
		return (append(_Right.data(), _Convert_size<size_type>(_Right.size())));
	}

	template<class _StringViewIsh,
		class = _Is_string_view_ish<_StringViewIsh>>
		basic_string & append(const _StringViewIsh& _Right, const size_type _Roff, const size_type _Count = npos)
	{	// append _Right [_Roff, _Roff + _Count)
		basic_string_view<_Elem, _Traits> _As_view = _Right;
		return (append(_As_view.substr(_Roff, _Count)));
	}
#endif /* _HAS_CXX17 */

	basic_string& append(_In_reads_(_Count) const _Elem * const _Ptr, _CRT_GUARDOVERFLOW const size_type _Count)
	{	// append [_Ptr, _Ptr + _Count)
		auto& _My_data = this->_Get_data();
		const size_type _Old_size = _My_data._Mysize;
		if (_Count <= _My_data._Myres - _Old_size)
		{
			_My_data._Mysize = _Old_size + _Count;
			_Elem * const _Old_ptr = _My_data._Myptr();
			_Traits::move(_Old_ptr + _Old_size, _Ptr, _Count);
			_Traits::assign(_Old_ptr[_Old_size + _Count], _Elem());
			return (*this);
		}

		return (_Reallocate_grow_by(_Count,
			[](_Elem * const _New_ptr, const _Elem * const _Old_ptr, const size_type _Old_size,
				const _Elem * const _Ptr, const size_type _Count) {
			_Traits::copy(_New_ptr, _Old_ptr, _Old_size);
			_Traits::copy(_New_ptr + _Old_size, _Ptr, _Count);
			_Traits::assign(_New_ptr[_Old_size + _Count], _Elem());
		}, _Ptr, _Count));
	}

	basic_string& append(_In_z_ const _Elem * const _Ptr)
	{	// append [_Ptr, <null>)
		return (append(_Ptr, _Convert_size<size_type>(_Traits::length(_Ptr))));
	}

	basic_string& append(_CRT_GUARDOVERFLOW const size_type _Count, const _Elem _Ch)
	{	// append _Count * _Ch
		auto& _My_data = this->_Get_data();
		const size_type _Old_size = _My_data._Mysize;
		if (_Count <= _My_data._Myres - _Old_size)
		{
			_My_data._Mysize = _Old_size + _Count;
			_Elem * const _Old_ptr = _My_data._Myptr();
			_Traits::assign(_Old_ptr + _Old_size, _Count, _Ch);
			_Traits::assign(_Old_ptr[_Old_size + _Count], _Elem());
			return (*this);
		}

		return (_Reallocate_grow_by(_Count,
			[](_Elem * const _New_ptr, const _Elem * const _Old_ptr, const size_type _Old_size,
				const size_type _Count, const _Elem _Ch) {
			_Traits::copy(_New_ptr, _Old_ptr, _Old_size);
			_Traits::assign(_New_ptr + _Old_size, _Count, _Ch);
			_Traits::assign(_New_ptr[_Old_size + _Count], _Elem());
		}, _Count, _Ch));
	}

	template<class _Iter,
		class = enable_if_t<_Is_iterator_v<_Iter>>>
		basic_string& append(const _Iter _First, const _Iter _Last)
	{	// append [_First, _Last), input iterators
		return (replace(end(), end(), _First, _Last));
	}

	basic_string& assign(const basic_string& _Right)
	{	// assign _Right
		*this = _Right;
		return (*this);
	}

	basic_string& assign(const basic_string& _Right, const size_type _Roff, size_type _Count = npos)
	{	// assign _Right [_Roff, _Roff + _Count)
		auto& _Right_data = _Right._Get_data();
		_Right_data._Check_offset(_Roff);
		_Count = _Right_data._Clamp_suffix_size(_Roff, _Count);
		return (assign(_Right_data._Myptr() + _Roff, _Count));
	}

#if _HAS_CXX17
	basic_string& assign(const basic_string_view<_Elem, _Traits> _Right)
	{	// assign _Right
		return (assign(_Right.data(), _Convert_size<size_type>(_Right.size())));
	}

	template<class _StringViewIsh,
		class = _Is_string_view_ish<_StringViewIsh>>
		basic_string & assign(const _StringViewIsh& _Right, const size_type _Roff, const size_type _Count = npos)
	{	// assign _Right [_Roff, _Roff + _Count)
		basic_string_view<_Elem, _Traits> _As_view = _Right;
		return (assign(_As_view.substr(_Roff, _Count)));
	}
#endif /* _HAS_CXX17 */

	basic_string& assign(_In_reads_(_Count) const _Elem * const _Ptr, _CRT_GUARDOVERFLOW const size_type _Count)
	{	// assign [_Ptr, _Ptr + _Count)
		auto& _My_data = this->_Get_data();
		if (_Count <= _My_data._Myres)
		{
			_Elem * const _Old_ptr = _My_data._Myptr();
			_My_data._Mysize = _Count;
			_Traits::move(_Old_ptr, _Ptr, _Count);
			_Traits::assign(_Old_ptr[_Count], _Elem());
			return (*this);
		}

		return (_Reallocate_for(_Count, [](_Elem * const _New_ptr, const size_type _Count, const _Elem * const _Ptr) {
			_Traits::copy(_New_ptr, _Ptr, _Count);
			_Traits::assign(_New_ptr[_Count], _Elem());
		}, _Ptr));
	}

	basic_string& assign(_In_z_ const _Elem * const _Ptr)
	{	// assign [_Ptr, <null>)
		return (assign(_Ptr, _Convert_size<size_type>(_Traits::length(_Ptr))));
	}

	basic_string& assign(_CRT_GUARDOVERFLOW const size_type _Count, const _Elem _Ch)
	{	// assign _Count * _Ch
		auto& _My_data = this->_Get_data();
		if (_Count <= _My_data._Myres)
		{
			_Elem * const _Old_ptr = _My_data._Myptr();
			_My_data._Mysize = _Count;
			_Traits::assign(_Old_ptr, _Count, _Ch);
			_Traits::assign(_Old_ptr[_Count], _Elem());
			return (*this);
		}

		return (_Reallocate_for(_Count, [](_Elem * const _New_ptr, const size_type _Count, const _Elem _Ch) {
			_Traits::assign(_New_ptr, _Count, _Ch);
			_Traits::assign(_New_ptr[_Count], _Elem());
		}, _Ch));
	}

	template<class _Iter,
		class = enable_if_t<_Is_iterator_v<_Iter>>>
		basic_string& assign(const _Iter _First, const _Iter _Last)
	{	// assign [_First, _Last), input iterators
		return (replace(begin(), end(), _First, _Last));
	}

	basic_string& insert(const size_type _Off, const basic_string& _Right)
	{	// insert _Right at _Off
		auto& _Right_data = _Right._Get_data();
		return (insert(_Off, _Right_data._Myptr(), _Right_data._Mysize));
	}

	basic_string& insert(const size_type _Off, const basic_string& _Right, const size_type _Roff, size_type _Count = npos)
	{	// insert _Right [_Roff, _Roff + _Count) at _Off
		auto& _Right_data = _Right._Get_data();
		_Right_data._Check_offset(_Roff);
		_Count = _Right_data._Clamp_suffix_size(_Roff, _Count);
		return (insert(_Off, _Right_data._Myptr() + _Roff, _Count));
	}

#if _HAS_CXX17
	basic_string& insert(const size_type _Off, const basic_string_view<_Elem, _Traits> _Right)
	{	// insert _Right at _Off
		return (insert(_Off, _Right.data(), _Convert_size<size_type>(_Right.size())));
	}

	template<class _StringViewIsh,
		class = _Is_string_view_ish<_StringViewIsh>>
		basic_string & insert(const size_type _Off,
			const _StringViewIsh& _Right, const size_type _Roff, const size_type _Count = npos)
	{	// insert _Right [_Roff, _Roff + _Count) at _Off
		basic_string_view<_Elem, _Traits> _As_view = _Right;
		return (insert(_Off, _As_view.substr(_Roff, _Count)));
	}
#endif /* _HAS_CXX17 */

	basic_string& insert(const size_type _Off, _In_reads_(_Count) const _Elem * const _Ptr,
		_CRT_GUARDOVERFLOW const size_type _Count)
	{	// insert [_Ptr, _Ptr + _Count) at _Off
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		const size_type _Old_size = _My_data._Mysize;
		if (_Count <= _My_data._Myres - _Old_size)
		{
			_My_data._Mysize = _Old_size + _Count;
			_Elem * const _Old_ptr = _My_data._Myptr();
			_Elem * const _Insert_at = _Old_ptr + _Off;
			// the range [_Ptr, _Ptr + _Ptr_shifted_after) is left alone by moving the suffix out,
			// while the range [_Ptr + _Ptr_shifted_after, _Ptr + _Count) shifts down by _Count
			size_type _Ptr_shifted_after;
			if (_Ptr + _Count <= _Insert_at || _Ptr > _Old_ptr + _Old_size)
			{	// inserted content is before the shifted region, or does not alias
				_Ptr_shifted_after = _Count; // none of _Ptr's data shifts
			}
			else if (_Insert_at <= _Ptr)
			{	// all of [_Ptr, _Ptr + _Count) shifts
				_Ptr_shifted_after = 0;
			}
			else
			{	// [_Ptr, _Ptr + _Count) contains _Insert_at, so only the part after _Insert_at shifts
				_Ptr_shifted_after = static_cast<size_type>(_Insert_at - _Ptr);
			}

			_Traits::move(_Insert_at + _Count, _Insert_at, _Old_size - _Off + 1); // move suffix + null down
			_Traits::copy(_Insert_at, _Ptr, _Ptr_shifted_after);
			_Traits::copy(_Insert_at + _Ptr_shifted_after, _Ptr + _Count + _Ptr_shifted_after,
				_Count - _Ptr_shifted_after);
			return (*this);
		}

		return (_Reallocate_grow_by(_Count,
			[](_Elem * const _New_ptr, const _Elem * const _Old_ptr, const size_type _Old_size,
				const size_type _Off, const _Elem * const _Ptr, const size_type _Count) {
			_Traits::copy(_New_ptr, _Old_ptr, _Off);
			_Traits::copy(_New_ptr + _Off, _Ptr, _Count);
			_Traits::copy(_New_ptr + _Off + _Count, _Old_ptr + _Off, _Old_size - _Off + 1);
		}, _Off, _Ptr, _Count));
	}

	basic_string& insert(const size_type _Off, _In_z_ const _Elem * const _Ptr)
	{	// insert [_Ptr, <null>) at _Off
		return (insert(_Off, _Ptr, _Convert_size<size_type>(_Traits::length(_Ptr))));
	}

	basic_string& insert(const size_type _Off, _CRT_GUARDOVERFLOW const size_type _Count, const _Elem _Ch)
	{	// insert _Count * _Ch at _Off
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		const size_type _Old_size = _My_data._Mysize;
		if (_Count <= _My_data._Myres - _Old_size)
		{
			_My_data._Mysize = _Old_size + _Count;
			_Elem * const _Old_ptr = _My_data._Myptr();
			_Elem * const _Insert_at = _Old_ptr + _Off;
			_Traits::move(_Insert_at + _Count, _Insert_at, _Old_size - _Off + 1); // move suffix + null down
			_Traits::assign(_Insert_at, _Count, _Ch); // fill hole
			return (*this);
		}

		return (_Reallocate_grow_by(_Count,
			[](_Elem * const _New_ptr, const _Elem * const _Old_ptr, const size_type _Old_size,
				const size_type _Off, const size_type _Count, const _Elem _Ch) {
			_Traits::copy(_New_ptr, _Old_ptr, _Off);
			_Traits::assign(_New_ptr + _Off, _Count, _Ch);
			_Traits::copy(_New_ptr + _Off + _Count, _Old_ptr + _Off, _Old_size - _Off + 1);
		}, _Off, _Count, _Ch));
	}

	iterator insert(const const_iterator _Where, const _Elem _Ch)
	{	// insert _Ch at _Where
		size_type _Off = _Where - begin();
		insert(_Off, 1, _Ch);
		return (begin() + _Off);
	}

	iterator insert(const const_iterator _Where, _CRT_GUARDOVERFLOW const size_type _Count, const _Elem _Ch)
	{	// insert _Count * _Elem at _Where
		const size_type _Off = _Where - begin();
		insert(_Off, _Count, _Ch);
		return (begin() + _Off);
	}

	template<class _Iter,
		class = enable_if_t<_Is_iterator_v<_Iter>>>
		iterator insert(const const_iterator _Where, const _Iter _First, const _Iter _Last)
	{	// insert [_First, _Last) at _Where, input iterators
		const size_type _Off = _Where - begin();
		replace(_Where, _Where, _First, _Last);
		return (begin() + _Off);
	}

	basic_string& erase(const size_type _Off = 0)
	{	// erase elements [_Off, ...)
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		_Eos(_Off);
		return (*this);
	}

	basic_string& erase(const size_type _Off, size_type _Count)
	{	// erase elements [_Off, _Off + _Count)
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		_Count = _My_data._Clamp_suffix_size(_Off, _Count);
		const size_type _Old_size = _My_data._Mysize;
		_Elem * const _My_ptr = _My_data._Myptr();
		_Elem * const _Erase_at = _My_ptr + _Off;
		const size_type _New_size = _Old_size - _Count;
		_My_data._Mysize = _New_size;
		_Traits::move(_Erase_at, _Erase_at + _Count, _New_size - _Off + 1); // move suffix + null up
		return (*this);
	}

	iterator erase(const const_iterator _Where)
	{	// erase element at _Where
		const size_type _Off = _Where - begin();
		erase(_Off, 1);
		return (begin() + _Off);
	}

	iterator erase(const const_iterator _First, const const_iterator _Last)
	{	// erase substring [_First, _Last)
		_DEBUG_RANGE(_First, _Last);
		const size_type _Off = _First - begin();
		erase(_Off, _Last - _First);
		return (begin() + _Off);
	}

	void clear() _NOEXCEPT
	{	// erase all
		_Eos(0);
	}

	basic_string& replace(const size_type _Off, const size_type _N0, const basic_string& _Right)
	{	// replace [_Off, _Off + _N0) with _Right
		auto& _Right_data = _Right._Get_data();
		return (replace(_Off, _N0, _Right_data._Myptr(), _Right_data._Mysize));
	}

	basic_string& replace(const size_type _Off, size_type _N0,
		const basic_string& _Right, const size_type _Roff, size_type _Count = npos)
	{	// replace [_Off, _Off + _N0) with _Right [_Roff, _Roff + _Count)
		auto& _Right_data = _Right._Get_data();
		_Right_data._Check_offset(_Roff);
		_Count = _Right_data._Clamp_suffix_size(_Roff, _Count);
		return (replace(_Off, _N0, _Right_data._Myptr() + _Roff, _Count));
	}

#if _HAS_CXX17
	basic_string& replace(const size_type _Off, const size_type _N0, const basic_string_view<_Elem, _Traits> _Right)
	{	// replace [_Off, _Off + _N0) with _Right
		return (replace(_Off, _N0, _Right.data(), _Convert_size<size_type>(_Right.size())));
	}

	template<class _StringViewIsh,
		class = _Is_string_view_ish<_StringViewIsh>>
		basic_string & replace(const size_type _Off, const size_type _N0,
			const _StringViewIsh& _Right, const size_type _Roff, const size_type _Count = npos)
	{	// replace [_Off, _Off + _N0) with _Right [_Roff, _Roff + _Count)
		basic_string_view<_Elem, _Traits> _As_view = _Right;
		return (replace(_Off, _N0, _As_view.substr(_Roff, _Count)));
	}
#endif /* _HAS_CXX17 */

	basic_string& replace(const size_type _Off, size_type _N0,
		_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Count)
	{	// replace [_Off, _Off + _N0) with [_Ptr, _Ptr + _Count)
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		_N0 = _My_data._Clamp_suffix_size(_Off, _N0);
		if (_N0 == _Count)
		{	// size doesn't change, so a single move does the trick
			_Traits::move(_My_data._Myptr() + _Off, _Ptr, _Count);
			return (*this);
		}

		const size_type _Old_size = _My_data._Mysize;
		const size_type _Suffix_size = _Old_size - _N0 - _Off + 1;
		if (_Count < _N0)
		{	// suffix shifts backwards; we don't have to move anything out of the way
			_My_data._Mysize = _Old_size - (_N0 - _Count);
			_Elem * const _Old_ptr = _My_data._Myptr();
			_Elem * const _Insert_at = _Old_ptr + _Off;
			_Traits::move(_Insert_at, _Ptr, _Count);
			_Traits::move(_Insert_at + _Count, _Insert_at + _N0, _Suffix_size);
			return (*this);
		}

		const size_type _Growth = static_cast<size_type>(_Count - _N0);
		if (_Growth <= _My_data._Myres - _Old_size)
		{	// growth fits
			_My_data._Mysize = _Old_size + _Growth;
			_Elem * const _Old_ptr = _My_data._Myptr();
			_Elem * const _Insert_at = _Old_ptr + _Off;
			_Elem * const _Suffix_at = _Insert_at + _N0;

			size_type _Ptr_shifted_after; // see rationale in insert
			if (_Ptr + _Count <= _Insert_at || _Ptr > _Old_ptr + _Old_size)
			{
				_Ptr_shifted_after = _Count;
			}
			else if (_Suffix_at <= _Ptr)
			{
				_Ptr_shifted_after = 0;
			}
			else
			{
				_Ptr_shifted_after = static_cast<size_type>(_Suffix_at - _Ptr);
			}

			_Traits::move(_Suffix_at + _Growth, _Suffix_at, _Suffix_size);
			// next case must be move, in case _Ptr begins before _Insert_at and contains part of the hole;
			// this case doesn't occur in insert because the new content must come from outside the removed
			// content there (because in insert there is no removed content)
			_Traits::move(_Insert_at, _Ptr, _Ptr_shifted_after);
			// the next case can be copy, because it comes from the chunk moved out of the way in the
			// first move, and the hole we're filling can't alias the chunk we moved out of the way
			_Traits::copy(_Insert_at + _Ptr_shifted_after, _Ptr + _Growth + _Ptr_shifted_after,
				_Count - _Ptr_shifted_after);
			return (*this);
		}

		return (_Reallocate_grow_by(_Growth,
			[](_Elem * const _New_ptr, const _Elem * const _Old_ptr, const size_type _Old_size,
				const size_type _Off, const size_type _N0, const _Elem * const _Ptr, const size_type _Count) {
			_Traits::copy(_New_ptr, _Old_ptr, _Off);
			_Traits::copy(_New_ptr + _Off, _Ptr, _Count);
			_Traits::copy(_New_ptr + _Off + _Count, _Old_ptr + _Off + _N0, _Old_size - _N0 - _Off + 1);
		}, _Off, _N0, _Ptr, _Count));
	}

	basic_string& replace(const size_type _Off, const size_type _N0, _In_z_ const _Elem * const _Ptr)
	{	// replace [_Off, _Off + _N0) with [_Ptr, <null>)
		return (replace(_Off, _N0, _Ptr, _Convert_size<size_type>(_Traits::length(_Ptr))));
	}

	basic_string& replace(const size_type _Off, size_type _N0, const size_type _Count, const _Elem _Ch)
	{	// replace [_Off, _Off + _N0) with _Count * _Ch
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		_N0 = _My_data._Clamp_suffix_size(_Off, _N0);
		if (_Count == _N0)
		{
			_Traits::assign(_My_data._Myptr() + _Off, _Count, _Ch);
			return (*this);
		}

		const size_type _Old_size = _My_data._Mysize;
		if (_Count < _N0 || _Count - _N0 <= _My_data._Myres - _Old_size)
		{	// either we are shrinking, or the growth fits
			_My_data._Mysize = _Old_size + _Count - _N0; // may temporarily overflow;
														 // OK because size_type must be unsigned
			_Elem * const _Old_ptr = _My_data._Myptr();
			_Elem * const _Insert_at = _Old_ptr + _Off;
			_Traits::move(_Insert_at + _Count, _Insert_at + _N0, _Old_size - _N0 - _Off + 1);
			_Traits::assign(_Insert_at, _Count, _Ch);
			return (*this);
		}

		return (_Reallocate_grow_by(_Count - _N0,
			[](_Elem * const _New_ptr, const _Elem * const _Old_ptr, const size_type _Old_size,
				const size_type _Off, const size_type _N0, const size_type _Count, const _Elem _Ch) {
			_Traits::copy(_New_ptr, _Old_ptr, _Off);
			_Traits::assign(_New_ptr + _Off, _Count, _Ch);
			_Traits::copy(_New_ptr + _Off + _Count, _Old_ptr + _Off + _N0, _Old_size - _N0 - _Off + 1);
		}, _Off, _N0, _Count, _Ch));
	}

	basic_string& replace(const const_iterator _First, const const_iterator _Last, const basic_string& _Right)
	{	// replace [_First, _Last) with _Right
		return (replace(_First - begin(), _Last - _First, _Right));
	}

#if _HAS_CXX17
	basic_string& replace(const const_iterator _First, const const_iterator _Last,
		const basic_string_view<_Elem, _Traits> _Right)
	{	// replace [_First, _Last) with _Right
		return (replace(_First - begin(), _Last - _First, _Right));
	}
#endif /* _HAS_CXX17 */

	basic_string& replace(const const_iterator _First, const const_iterator _Last,
		_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Count)
	{	// replace [_First, _Last) with [_Ptr, _Ptr + _Count)
		return (replace(_First - begin(), _Last - _First, _Ptr, _Count));
	}

	basic_string& replace(const const_iterator _First, const const_iterator _Last, _In_z_ const _Elem * const _Ptr)
	{	// replace [_First, _Last) with [_Ptr, <null>)
		return (replace(_First - begin(), _Last - _First, _Ptr));
	}

	basic_string& replace(const const_iterator _First, const const_iterator _Last,
		const size_type _Count, const _Elem _Ch)
	{	// replace [_First, _Last) with _Count * _Ch
		return (replace(_First - begin(), _Last - _First, _Count, _Ch));
	}

	template<class _Iter>
	basic_string& _Replace_range(const const_iterator _First, const const_iterator _Last,
		const _Iter _First2, const _Iter _Last2, false_type)
	{	// replace [_First, _Last) with [_First2, _Last2), input iterators
		const basic_string _Right(_First2, _Last2, get_allocator());
		replace(_First, _Last, _Right);
		return (*this);
	}

	template<class _Ptr>
	basic_string& _Replace_range(const const_iterator _First, const const_iterator _Last,
		const _Ptr _First2, const _Ptr _Last2, true_type)
	{	// replace [_First, _Last) with [_First2, _Last2), pointers
		return (replace(_First - cbegin(), _Last - _First, _First2, _Last2 - _First2));
	}

	template<class _Iter,
		class = enable_if_t<_Is_iterator_v<_Iter>>>
		basic_string& replace(const const_iterator _First, const const_iterator _Last,
			const _Iter _First2, const _Iter _Last2)
	{	// replace [_First, _Last) with [_First2, _Last2), input iterators
		_DEBUG_RANGE(_First2, _Last2);
		const auto _UFirst2 = _Unchecked(_First2);
		const auto _ULast2 = _Unchecked(_Last2);
		return (_Replace_range(_First, _Last, _UFirst2, _ULast2, _Is_elem_cptr<decltype(_UFirst2)>()));
	}

	iterator begin() _NOEXCEPT
	{	// return iterator for beginning of mutable sequence
		auto _My_data = _STD addressof(this->_Get_data());
		return (iterator(_Refancy<pointer>(_My_data->_Myptr()), _My_data));
	}

	const_iterator begin() const _NOEXCEPT
	{	// return iterator for beginning of immutable sequence
		auto _My_data = _STD addressof(this->_Get_data());
		return (const_iterator(_Refancy<const_pointer>(_My_data->_Myptr()), _My_data));
	}

	iterator end() _NOEXCEPT
	{	// return iterator for end of mutable sequence
		auto _My_data = _STD addressof(this->_Get_data());
		return (iterator(_Refancy<pointer>(_My_data->_Myptr()) + _My_data->_Mysize, _My_data));
	}

	const_iterator end() const _NOEXCEPT
	{	// return iterator for end of immutable sequence
		auto _My_data = _STD addressof(this->_Get_data());
		return (const_iterator(_Refancy<const_pointer>(_My_data->_Myptr()) + _My_data->_Mysize, _My_data));
	}

	_Elem * _Unchecked_begin() _NOEXCEPT
	{	// return pointer for beginning of mutable sequence
		return (this->_Get_data()._Myptr());
	}

	const _Elem * _Unchecked_begin() const _NOEXCEPT
	{	// return pointer for beginning of immutable sequence
		return (this->_Get_data()._Myptr());
	}

	_Elem * _Unchecked_end() _NOEXCEPT
	{	// return pointer for end of mutable sequence
		auto& _My_data = this->_Get_data();
		return (_My_data._Myptr() + _My_data._Mysize);
	}

	const _Elem * _Unchecked_end() const _NOEXCEPT
	{	// return pointer for end of immutable sequence
		const auto& _My_data = this->_Get_data();
		return (_My_data._Myptr() + _My_data._Mysize);
	}

	reverse_iterator rbegin() _NOEXCEPT
	{	// return iterator for beginning of reversed mutable sequence
		return (reverse_iterator(end()));
	}

	const_reverse_iterator rbegin() const _NOEXCEPT
	{	// return iterator for beginning of reversed immutable sequence
		return (const_reverse_iterator(end()));
	}

	reverse_iterator rend() _NOEXCEPT
	{	// return iterator for end of reversed mutable sequence
		return (reverse_iterator(begin()));
	}

	const_reverse_iterator rend() const _NOEXCEPT
	{	// return iterator for end of reversed immutable sequence
		return (const_reverse_iterator(begin()));
	}

	const_iterator cbegin() const _NOEXCEPT
	{	// return iterator for beginning of immutable sequence
		return (begin());
	}

	const_iterator cend() const _NOEXCEPT
	{	// return iterator for end of immutable sequence
		return (end());
	}

	const_reverse_iterator crbegin() const _NOEXCEPT
	{	// return iterator for beginning of reversed immutable sequence
		return (rbegin());
	}

	const_reverse_iterator crend() const _NOEXCEPT
	{	// return iterator for end of reversed immutable sequence
		return (rend());
	}

	void shrink_to_fit()
	{	// reduce capacity
		auto& _My_data = this->_Get_data();
		if (!_My_data._Large_string_engaged())
		{	// can't shrink from small mode
			return;
		}

		if (_My_data._Mysize < this->_BUF_SIZE)
		{
			_Become_small();
			return;
		}

		const size_type _Target_capacity = _Min_value(_My_data._Mysize | this->_ALLOC_MASK, max_size());
		if (_Target_capacity < _My_data._Myres)
		{	// worth shrinking, do it
			auto& _Al = this->_Getal();
			const pointer _New_ptr = _Al.allocate(_Target_capacity + 1); // throws
			this->_Orphan_all();
			_Traits::copy(_Unfancy(_New_ptr), _Unfancy(_My_data._Bx._Ptr), _My_data._Mysize + 1);
			_Al.deallocate(_My_data._Bx._Ptr, _My_data._Myres + 1);
			_My_data._Bx._Ptr = _New_ptr;
			_My_data._Myres = _Target_capacity;
		}
	}

	reference at(const size_type _Off)
	{	// subscript mutable sequence with checking
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset_exclusive(_Off);
		return (_My_data._Myptr()[_Off]);
	}

	const_reference at(const size_type _Off) const
	{	// subscript immutable sequence with checking
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset_exclusive(_Off);
		return (_My_data._Myptr()[_Off]);
	}

	reference operator[](const size_type _Off)
	{	// subscript mutable sequence
		auto& _My_data = this->_Get_data();
		_IDL_VERIFY(_Off <= _My_data._Mysize, "string subscript out of range");
		return (_My_data._Myptr()[_Off]);
	}

	const_reference operator[](const size_type _Off) const
	{	// subscript immutable sequence
		auto& _My_data = this->_Get_data();
		_IDL_VERIFY(_Off <= _My_data._Mysize, "string subscript out of range");
		return (_My_data._Myptr()[_Off]);
	}

#if _HAS_CXX17
	/* implicit */ operator basic_string_view<_Elem, _Traits>() const _NOEXCEPT
	{	// return a string_view around *this's character-type sequence
		auto& _My_data = this->_Get_data();
		return (basic_string_view<_Elem, _Traits>(_My_data._Myptr(), _My_data._Mysize));
	}
#endif /* _HAS_CXX17 */

	void push_back(const _Elem _Ch)
	{	// insert element at end
		auto& _My_data = this->_Get_data();
		const size_type _Old_size = _My_data._Mysize;
		if (_Old_size < _My_data._Myres)
		{
			_My_data._Mysize = _Old_size + 1;
			_Elem * const _Ptr = _My_data._Myptr();
			_Traits::assign(_Ptr[_Old_size], _Ch);
			_Traits::assign(_Ptr[_Old_size + 1], _Elem());
			return;
		}

		_Reallocate_grow_by(1,
			[](_Elem * const _New_ptr, const _Elem * const _Old_ptr, const size_type _Old_size,
				const _Elem _Ch) {
			_Traits::copy(_New_ptr, _Old_ptr, _Old_size);
			_Traits::assign(_New_ptr[_Old_size], _Ch);
			_Traits::assign(_New_ptr[_Old_size + 1], _Elem());
		}, _Ch);
	}

	void pop_back()
	{	// erase element at end
		auto& _My_data = this->_Get_data();
		const size_type _Old_size = _My_data._Mysize;
		_IDL_VERIFY(_Old_size != 0, "invalid to pop_back empty string");
		_Eos(_Old_size - 1);
	}

	reference front()
	{	// return first element of mutable sequence
		return (*begin());
	}

	const_reference front() const
	{	// return first element of immutable sequence
		return (*begin());
	}

	reference back()
	{	// return last element of mutable sequence
		return (*(end() - 1));
	}

	const_reference back() const
	{	// return last element of immutable sequence
		return (*(end() - 1));
	}

	_Ret_z_ const _Elem * c_str() const _NOEXCEPT
	{	// return pointer to null-terminated immutable array
		return (this->_Get_data()._Myptr());
	}

	_Ret_z_ const _Elem * data() const _NOEXCEPT
	{	// return pointer to immutable array
		return (this->_Get_data()._Myptr());
	}

#if _HAS_CXX17
	_Ret_z_ _Elem * data() _NOEXCEPT
	{	// return pointer to mutable array
		return (this->_Get_data()._Myptr());
	}
#endif /* _HAS_CXX17 */

	size_type length() const _NOEXCEPT
	{	// return length of sequence
		return (this->_Get_data()._Mysize);
	}

	size_type size() const _NOEXCEPT
	{	// return length of sequence
		return (this->_Get_data()._Mysize);
	}

	size_type max_size() const _NOEXCEPT
	{	// return maximum possible length of sequence
		const size_type _Alloc_max = _Alty_traits::max_size(this->_Getal());
		const size_type _Storage_max = // can always store small string
			_Max_value(_Alloc_max, static_cast<size_type>(this->_BUF_SIZE));
		return (_Min_value(
			static_cast<size_type>((numeric_limits<difference_type>::max)()),
			_Storage_max - 1 // -1 is for null terminator and/or npos
		));

	}

	void resize(_CRT_GUARDOVERFLOW const size_type _Newsize, const _Elem _Ch = _Elem())
	{	// determine new length, padding with _Ch elements as needed
		const size_type _Old_size = size();
		if (_Newsize <= _Old_size)
		{
			_Eos(_Newsize);
		}
		else
		{
			append(_Newsize - _Old_size, _Ch);
		}
	}

	size_type capacity() const _NOEXCEPT
	{	// return current length of allocated storage
		return (this->_Get_data()._Myres);
	}

	void reserve(_CRT_GUARDOVERFLOW const size_type _Newcap = 0)
	{	// determine new minimum length of allocated storage
		auto& _My_data = this->_Get_data();
		if (_My_data._Mysize > _Newcap)
		{	// requested capacity is not large enough for current size, ignore
			return;	// nothing to do
		}

		if (_My_data._Myres == _Newcap)
		{	// we're already at the requested capacity
			return;	// nothing to do
		}

		if (_My_data._Myres < _Newcap)
		{	// reallocate to grow
			const size_type _Old_size = _My_data._Mysize;
			_Reallocate_grow_by(_Newcap - _Old_size,
				[](_Elem * const _New_ptr, const _Elem * const _Old_ptr, const size_type _Old_size) {
				_Traits::copy(_New_ptr, _Old_ptr, _Old_size + 1);
			});

			_My_data._Mysize = _Old_size;
			return;
		}

		if (this->_BUF_SIZE > _Newcap && _My_data._Large_string_engaged())
		{	// deallocate everything; switch back to "small" mode
			_Become_small();
			return;
		}

		// ignore requests to reserve to [_BUF_SIZE, _Myres)
	}

	bool empty() const _NOEXCEPT
	{	// test if sequence is empty
		return (size() == 0);
	}

	_SCL_INSECURE_DEPRECATE_FN(basic_string::copy)
		size_type copy(_Out_writes_(_Count) _Elem * const _Ptr,
			size_type _Count, const size_type _Off = 0) const
	{	// copy [_Off, _Off + _Count) to [_Ptr, _Ptr + _Count)
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		_Count = _My_data._Clamp_suffix_size(_Off, _Count);
		_Traits::copy(_Ptr, _My_data._Myptr() + _Off, _Count);
		return (_Count);
	}

	_Pre_satisfies_(_Dest_size >= _Count) size_type _Copy_s(
		_Out_writes_all_(_Dest_size) _Elem * const _Dest, const size_type _Dest_size,
		size_type _Count, const size_type _Off = 0) const
	{	// copy [_Off, _Off + _Count) to [_Dest, _Dest + _Dest_size)
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		_Count = _My_data._Clamp_suffix_size(_Off, _Count);
		_Traits::_Copy_s(_Dest, _Dest_size, _My_data._Myptr() + _Off, _Count);
		return (_Count);
	}

	void _Swap_data(basic_string& _Right, true_type)
	{	// exchange _Get_data() with _Right._Get_data(), memcpy optimization
		const auto _My_data_mem = reinterpret_cast<unsigned char *>(_STD addressof(this->_Get_data()))
			+ _Memcpy_move_offset;
		const auto _Right_data_mem = reinterpret_cast<unsigned char *>(_STD addressof(_Right._Get_data()))
			+ _Memcpy_move_offset;
		unsigned char _Temp_mem[_Memcpy_move_size];
		_CSTD memcpy(_Temp_mem, _My_data_mem, _Memcpy_move_size);
		_CSTD memcpy(_My_data_mem, _Right_data_mem, _Memcpy_move_size);
		_CSTD memcpy(_Right_data_mem, _Temp_mem, _Memcpy_move_size);
	}

	void _Swap_bx_large_with_small(_Mydata_t& _Starts_large, _Mydata_t& _Starts_small)
	{	// exchange a string in large mode with one in small mode
		const pointer _Ptr = _Starts_large._Bx._Ptr;
		auto& _Al = this->_Getal();
		_Alty_traits::destroy(_Al, _STD addressof(_Starts_large._Bx._Ptr));
		_Traits::copy(_Starts_large._Bx._Buf, _Starts_small._Bx._Buf, this->_BUF_SIZE);
		_Alty_traits::construct(_Al, _STD addressof(_Starts_small._Bx._Ptr), _Ptr);
	}

	void _Swap_data(basic_string& _Right, false_type)
	{	// exchange _Get_data() with _Right._Get_data(), general case
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		const bool _My_large = _My_data._Large_string_engaged();
		const bool _Right_large = _Right_data._Large_string_engaged();
		if (_My_large)
		{
			if (_Right_large)
			{	// swap buffers, iterators preserved
				_Swap_adl(_My_data._Bx._Ptr, _Right_data._Bx._Ptr);
			}
			else
			{	// swap large with small
				_Swap_bx_large_with_small(_My_data, _Right_data);
			}
		}
		else
		{
			if (_Right_large)
			{	// swap small with large
				_Swap_bx_large_with_small(_Right_data, _My_data);
			}
			else
			{
				_Elem _Temp_buf[this->_BUF_SIZE];
				_Traits::copy(_Temp_buf, _My_data._Bx._Buf, this->_BUF_SIZE);
				_Traits::copy(_My_data._Bx._Buf, _Right_data._Bx._Buf, this->_BUF_SIZE);
				_Traits::copy(_Right_data._Bx._Buf, _Temp_buf, this->_BUF_SIZE);
			}
		}

		_STD swap(_My_data._Mysize, _Right_data._Mysize);
		_STD swap(_My_data._Myres, _Right_data._Myres);
	}

	void swap(basic_string& _Right) _NOEXCEPT // Strengthened
	{	// exchange contents with _Right
		if (this != _STD addressof(_Right))
		{	// (maybe) swap allocators, swap control information
			_Pocs(this->_Getal(), _Right._Getal());

#if _ITERATOR_DEBUG_LEVEL != 0
			auto& _My_data = this->_Get_data();
			auto& _Right_data = _Right._Get_data();
			const bool _My_large = _My_data._Large_string_engaged();
			const bool _Right_large = _Right_data._Large_string_engaged();
			if (!_My_large)
			{
				_My_data._Orphan_all();
			}

			if (!_Right_large)
			{
				_Right_data._Orphan_all();
			}

			if (_My_large || _Right_large)
			{
				_My_data._Swap_all(_Right_data);
			}
#endif /* _ITERATOR_DEBUG_LEVEL != 0 */
		}

		_Swap_data(_Right, _Use_memcpy_move{});
	}

#if _HAS_CXX17
	size_type find(const basic_string_view<_Elem, _Traits> _Right, const size_type _Off = 0) const _NOEXCEPT
	{	// look for _Right beginning at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Right.data(), _Right.size())));
	}
#endif /* _HAS_CXX17 */

	size_type find(const basic_string& _Right, const size_type _Off = 0) const _NOEXCEPT
	{	// look for _Right beginning at or after _Off
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		return (static_cast<size_type>(
			_Traits_find<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
				_Right_data._Myptr(), _Right_data._Mysize)));
	}

	size_type find(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off, const size_type _Count) const
		_NOEXCEPT // strengthened
	{	// look for [_Ptr, _Ptr + _Count) beginning at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Count)));
	}

	size_type find(_In_z_ const _Elem * const _Ptr, const size_type _Off = 0) const _NOEXCEPT // strengthened
	{	// look for [_Ptr, <null>) beginning at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Traits::length(_Ptr))));
	}

	size_type find(const _Elem _Ch, const size_type _Off = 0) const _NOEXCEPT // strengthened
	{	// look for _Ch at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find_ch<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ch)));
	}

#if _HAS_CXX17
	size_type rfind(const basic_string_view<_Elem, _Traits> _Right, const size_type _Off = npos) const _NOEXCEPT
	{	// look for _Right beginning before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_rfind<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Right.data(), _Right.size())));
	}
#endif /* _HAS_CXX17 */

	size_type rfind(const basic_string& _Right, const size_type _Off = npos) const _NOEXCEPT
	{	// look for _Right beginning before _Off
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		return (static_cast<size_type>(
			_Traits_rfind<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
				_Right_data._Myptr(), _Right_data._Mysize)));
	}

	size_type rfind(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off, const size_type _Count) const
		_NOEXCEPT // strengthened
	{	// look for [_Ptr, _Ptr + _Count) beginning before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_rfind<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Count)));
	}

	size_type rfind(_In_z_ const _Elem * const _Ptr, const size_type _Off = npos) const _NOEXCEPT // strengthened
	{	// look for [_Ptr, <null>) beginning before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_rfind<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Traits::length(_Ptr))));
	}

	size_type rfind(const _Elem _Ch, const size_type _Off = npos) const _NOEXCEPT // strengthened
	{	// look for _Ch before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_rfind_ch<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ch)));
	}

#if _HAS_CXX17
	size_type find_first_of(const basic_string_view<_Elem, _Traits> _Right, const size_type _Off = 0) const _NOEXCEPT
	{	// look for one of _Right at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(_Traits_find_first_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
			_Right.data(), _Right.size())));
	}
#endif /* _HAS_CXX17 */

	size_type find_first_of(const basic_string& _Right, const size_type _Off = 0) const _NOEXCEPT
	{	// look for one of _Right at or after _Off
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		return (static_cast<size_type>(_Traits_find_first_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
			_Right_data._Myptr(), _Right_data._Mysize)));
	}

	size_type find_first_of(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off,
		const size_type _Count) const _NOEXCEPT // strengthened
	{	// look for one of [_Ptr, _Ptr + _Count) at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find_first_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Count)));
	}

	size_type find_first_of(_In_z_ const _Elem * const _Ptr, const size_type _Off = 0) const _NOEXCEPT // strengthened
	{	// look for one of [_Ptr, <null>) at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find_first_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Traits::length(_Ptr))));
	}

	size_type find_first_of(const _Elem _Ch, const size_type _Off = 0) const _NOEXCEPT // strengthened
	{	// look for _Ch at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find_ch<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ch)));
	}

#if _HAS_CXX17
	size_type find_last_of(const basic_string_view<_Elem, _Traits> _Right, const size_type _Off = npos) const _NOEXCEPT
	{	// look for one of _Right before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(_Traits_find_last_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
			_Right.data(), _Right.size())));
	}
#endif /* _HAS_CXX17 */

	size_type find_last_of(const basic_string& _Right, size_type _Off = npos) const _NOEXCEPT
	{	// look for one of _Right before _Off
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		return (static_cast<size_type>(_Traits_find_last_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
			_Right_data._Myptr(), _Right_data._Mysize)));
	}

	size_type find_last_of(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off,
		const size_type _Count) const _NOEXCEPT // strengthened
	{	// look for one of [_Ptr, _Ptr + _Count) before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find_last_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Count)));
	}

	size_type find_last_of(_In_z_ const _Elem * const _Ptr, const size_type _Off = npos) const _NOEXCEPT // strengthened
	{	// look for one of [_Ptr, <null>) before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find_last_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Traits::length(_Ptr))));
	}

	size_type find_last_of(const _Elem _Ch, const size_type _Off = npos) const _NOEXCEPT // strengthened
	{	// look for _Ch before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(_Traits_rfind_ch<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ch)));
	}

#if _HAS_CXX17
	size_type find_first_not_of(const basic_string_view<_Elem, _Traits> _Right, const size_type _Off = 0) const
		_NOEXCEPT
	{	// look for none of _Right at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(_Traits_find_first_not_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
			_Right.data(), _Right.size())));
	}
#endif /* _HAS_CXX17 */

	size_type find_first_not_of(const basic_string& _Right, const size_type _Off = 0) const _NOEXCEPT
	{	// look for none of _Right at or after _Off
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		return (static_cast<size_type>(_Traits_find_first_not_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
			_Right_data._Myptr(), _Right_data._Mysize)));
	}

	size_type find_first_not_of(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off,
		const size_type _Count) const _NOEXCEPT // strengthened
	{	// look for none of [_Ptr, _Ptr + _Count) at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find_first_not_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Count)));
	}

	size_type find_first_not_of(_In_z_ const _Elem * const _Ptr, size_type _Off = 0) const _NOEXCEPT // strengthened
	{	// look for one of [_Ptr, <null>) at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find_first_not_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Traits::length(_Ptr))));
	}

	size_type find_first_not_of(const _Elem _Ch, const size_type _Off = 0) const _NOEXCEPT // strengthened
	{	// look for non _Ch at or after _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(_Traits_find_not_ch<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ch)));
	}

#if _HAS_CXX17
	size_type find_last_not_of(const basic_string_view<_Elem, _Traits> _Right, const size_type _Off = npos) const
		_NOEXCEPT
	{	// look for none of _Right before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(_Traits_find_last_not_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
			_Right.data(), _Right.size())));
	}
#endif /* _HAS_CXX17 */

	size_type find_last_not_of(const basic_string& _Right, const size_type _Off = npos) const _NOEXCEPT
	{	// look for none of _Right before _Off
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		return (static_cast<size_type>(_Traits_find_last_not_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
			_Right_data._Myptr(), _Right_data._Mysize)));
	}

	size_type find_last_not_of(_In_reads_(_Count) const _Elem * const _Ptr, const size_type _Off,
		const size_type _Count) const _NOEXCEPT // strengthened
	{	// look for none of [_Ptr, _Ptr + _Count) before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_find_last_not_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ptr, _Count)));
	}

	size_type find_last_not_of(_In_z_ const _Elem * const _Ptr, const size_type _Off = npos) const
		_NOEXCEPT // strengthened
	{	// look for none of [_Ptr, <null>) before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(_Traits_find_last_not_of<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off,
			_Ptr, _Traits::length(_Ptr))));
	}

	size_type find_last_not_of(const _Elem _Ch, const size_type _Off = npos) const _NOEXCEPT // strengthened
	{	// look for non _Ch before _Off
		auto& _My_data = this->_Get_data();
		return (static_cast<size_type>(
			_Traits_rfind_not_ch<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Off, _Ch)));
	}

	basic_string substr(const size_type _Off = 0, const size_type _Count = npos) const
	{	// return [_Off, _Off + _Count) as new string
		return (basic_string(*this, _Off, _Count, get_allocator()));
	}

	bool _Equal(const basic_string& _Right) const _NOEXCEPT
	{	// compare [0, size()) with _Right for equality
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		return (_Traits_equal<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Right_data._Myptr(), _Right_data._Mysize));
	}

	bool _Equal(_In_z_ const _Elem * const _Ptr) const _NOEXCEPT
	{	// compare [0, size()) with _Ptr for equality
		auto& _My_data = this->_Get_data();
		return (_Traits_equal<_Traits>(_My_data._Myptr(), _My_data._Mysize, _Ptr, _Traits::length(_Ptr)));
	}

#if _HAS_CXX17
	int compare(const basic_string_view<_Elem, _Traits> _Right) const _NOEXCEPT
	{	// compare [0, size()) with _Right
		auto& _My_data = this->_Get_data();
		return (_Traits_compare<_Traits>(_My_data._Myptr(), _My_data._Mysize,
			_Right.data(), _Right.size()));
	}

	int compare(const size_type _Off, const size_type _N0,
		const basic_string_view<_Elem, _Traits> _Right) const
	{	// compare [_Off, _Off + _N0) with _Right
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		return (_Traits_compare<_Traits>(_My_data._Myptr() + _Off, _My_data._Clamp_suffix_size(_Off, _N0),
			_Right.data(), _Right.size()));
	}

	template<class _StringViewIsh,
		class = _Is_string_view_ish<_StringViewIsh>>
		int compare(const size_type _Off, const size_type _N0,
			const _StringViewIsh& _Right, const size_type _Roff, const size_type _Count = npos) const
	{	// compare [_Off, _Off + _N0) with _Right [_Roff, _Roff + _Count)
		basic_string_view<_Elem, _Traits> _As_view = _Right;
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		const auto _With_substr = _As_view.substr(_Roff, _Count);
		return (_Traits_compare<_Traits>(_My_data._Myptr() + _Off, _My_data._Clamp_suffix_size(_Off, _N0),
			_With_substr.data(), _With_substr.size()));
	}
#endif /* _HAS_CXX17 */

	int compare(const basic_string& _Right) const _NOEXCEPT
	{	// compare [0, size()) with _Right
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		return (_Traits_compare<_Traits>(_My_data._Myptr(), _My_data._Mysize,
			_Right_data._Myptr(), _Right_data._Mysize));
	}

	int compare(size_type _Off, size_type _N0, const basic_string& _Right) const
	{	// compare [_Off, _Off + _N0) with _Right
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		auto& _Right_data = _Right._Get_data();
		return (_Traits_compare<_Traits>(_My_data._Myptr() + _Off, _My_data._Clamp_suffix_size(_Off, _N0),
			_Right_data._Myptr(), _Right_data._Mysize));
	}

	int compare(const size_type _Off, const size_type _N0, const basic_string& _Right,
		const size_type _Roff, const size_type _Count = npos) const
	{	// compare [_Off, _Off + _N0) with _Right [_Roff, _Roff + _Count)
		auto& _My_data = this->_Get_data();
		auto& _Right_data = _Right._Get_data();
		_My_data._Check_offset(_Off);
		_Right_data._Check_offset(_Roff);
		return (_Traits_compare<_Traits>(_My_data._Myptr() + _Off, _My_data._Clamp_suffix_size(_Off, _N0),
			_Right_data._Myptr() + _Roff, _Right_data._Clamp_suffix_size(_Roff, _Count)));
	}

	int compare(_In_z_ const _Elem * const _Ptr) const _NOEXCEPT // strengthened
	{	// compare [0, size()) with [_Ptr, <null>)
		auto& _My_data = this->_Get_data();
		return (_Traits_compare<_Traits>(_My_data._Myptr(), _My_data._Mysize,
			_Ptr, _Traits::length(_Ptr)));
	}

	int compare(const size_type _Off, const size_type _N0, _In_z_ const _Elem * const _Ptr) const
	{	// compare [_Off, _Off + _N0) with [_Ptr, <null>)
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		return (_Traits_compare<_Traits>(_My_data._Myptr() + _Off, _My_data._Clamp_suffix_size(_Off, _N0),
			_Ptr, _Traits::length(_Ptr)));
	}

	int compare(const size_type _Off, const size_type _N0, _In_reads_(_Count) const _Elem * const _Ptr,
		const size_type _Count) const
	{	// compare [_Off, _Off + _N0) with [_Ptr, _Ptr + _Count)
		auto& _My_data = this->_Get_data();
		_My_data._Check_offset(_Off);
		return (_Traits_compare<_Traits>(_My_data._Myptr() + _Off, _My_data._Clamp_suffix_size(_Off, _N0),
			_Ptr, _Count));
	}

	allocator_type get_allocator() const _NOEXCEPT
	{	// return allocator object for values
		return (static_cast<allocator_type>(this->_Getal()));
	}

	size_type _Calculate_growth(const size_type _Requested) const
	{	// determines the next array size to allocate
		const size_type _Max = max_size();
		auto& _My_data = this->_Get_data();
		const size_type _Masked = _Requested | this->_ALLOC_MASK;
		if (_Masked > _Max)
		{	// the mask overflows, settle for max_size()
			return (_Max);
		}

		const size_type _Old = _My_data._Myres;
		if (_Old > _Max - _Old / 2)
		{	// similarly, geometric overflows
			return (_Max);
		}

		return (_Max_value(_Masked, _Old + _Old / 2));
	}

	template<class _Fty,
		class... _ArgTys>
		basic_string& _Reallocate_for(const size_type _New_size, _Fty _Fn, _ArgTys... _Args)
	{	// reallocate to store exactly _New_size elements, new buffer prepared by
		// _Fn(_New_ptr, _New_size, _Args...)
		if (_New_size > max_size())
		{
			_Xlen();	// result too long
		}

		auto& _My_data = this->_Get_data();
		const size_type _Old_capacity = _My_data._Myres;
		const size_type _New_capacity = _Calculate_growth(_New_size);
		auto& _Al = this->_Getal();
		const pointer _New_ptr = _Al.allocate(_New_capacity + 1); // throws
		_My_data._Orphan_all();
		_My_data._Mysize = _New_size;
		_My_data._Myres = _New_capacity;
		_Fn(_Unfancy(_New_ptr), _New_size, _Args...);
		if (this->_BUF_SIZE <= _Old_capacity)
		{
			_Al.deallocate(_My_data._Bx._Ptr, _Old_capacity + 1);
			_My_data._Bx._Ptr = _New_ptr;
		}
		else
		{
			_Alty_traits::construct(_Al, _STD addressof(_My_data._Bx._Ptr), _New_ptr);
		}

		return (*this);
	}

	template<class _Fty,
		class... _ArgTys>
		basic_string& _Reallocate_grow_by(const size_type _Size_increase, _Fty _Fn, _ArgTys... _Args)
	{	// reallocate to increase size by _Size_increase elements, new buffer prepared by
		// _Fn(_New_ptr, _Old_ptr, _Old_size, _Args...)
		auto& _My_data = this->_Get_data();
		const size_type _Old_size = _My_data._Mysize;
		if (max_size() - _Old_size < _Size_increase)
		{
			_Xlen();	// result too long
		}

		const size_type _New_size = _Old_size + _Size_increase;
		const size_type _Old_capacity = _My_data._Myres;
		const size_type _New_capacity = _Calculate_growth(_New_size);
		auto& _Al = this->_Getal();
		const pointer _New_ptr = _Al.allocate(_New_capacity + 1); // throws
		_My_data._Orphan_all();
		_My_data._Mysize = _New_size;
		_My_data._Myres = _New_capacity;
		_Elem * const _Raw_new = _Unfancy(_New_ptr);
		if (this->_BUF_SIZE <= _Old_capacity)
		{
			const pointer _Old_ptr = _My_data._Bx._Ptr;
			_Fn(_Raw_new, _Unfancy(_Old_ptr), _Old_size, _Args...);
			_Al.deallocate(_Old_ptr, _Old_capacity + 1);
			_My_data._Bx._Ptr = _New_ptr;
		}
		else
		{
			_Fn(_Raw_new, _My_data._Bx._Buf, _Old_size, _Args...);
			_Alty_traits::construct(_Al, _STD addressof(_My_data._Bx._Ptr), _New_ptr);
		}

		return (*this);
	}

	void _Become_small()
	{	// release any held storage and return to small string mode
		// pre: *this is in large string mode
		// pre: this is small enough to return to small string mode
		auto& _My_data = this->_Get_data();
		_My_data._Orphan_all();
		const pointer _Ptr = _My_data._Bx._Ptr;
		auto& _Al = this->_Getal();
		_Alty_traits::destroy(_Al, _STD addressof(_My_data._Bx._Ptr));
		_Traits::copy(_My_data._Bx._Buf, _Unfancy(_Ptr), _My_data._Mysize + 1);
		_Al.deallocate(_Ptr, _My_data._Myres + 1);
		_My_data._Myres = this->_BUF_SIZE - 1;
	}

	void _Eos(const size_type _Newsize)
	{	// set new length and null terminator
		auto& _My_data = this->_Get_data();
		_Traits::assign(_My_data._Myptr()[_My_data._Mysize = _Newsize], _Elem());
	}

	void _Tidy_init()
	{	// initialize basic_string data members
		auto& _My_data = this->_Get_data();
		_My_data._Mysize = 0;
		_My_data._Myres = this->_BUF_SIZE - 1;
		// the _Traits::assign is last so the codegen doesn't think the char
		// write can alias this
		_Traits::assign(_My_data._Bx._Buf[0], _Elem());
	}

	void _Tidy_deallocate()
	{	// initialize buffer, deallocating any storage
		this->_Orphan_all();
		auto& _My_data = this->_Get_data();
		if (_My_data._Large_string_engaged())
		{
			const pointer _Ptr = _My_data._Bx._Ptr;
			auto& _Al = this->_Getal();
			_Alty_traits::destroy(_Al, _STD addressof(_My_data._Bx._Ptr));
			_Al.deallocate(_Ptr, _My_data._Myres + 1);
		}

		_My_data._Mysize = 0;
		_My_data._Myres = this->_BUF_SIZE - 1;
		// the _Traits::assign is last so the codegen doesn't think the char
		// write can alias this
		_Traits::assign(_My_data._Bx._Buf[0], _Elem());
	}

	[[noreturn]] static void _Xlen()
	{	// report a length_error
		_Xlength_error("string too long");
	}
};

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	void swap(basic_string<_Elem, _Traits, _Alloc>& _Left,
		basic_string<_Elem, _Traits, _Alloc>& _Right) _NOEXCEPT // Strengthened
{	// swap _Left and _Right strings
	_Left.swap(_Right);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// return string + string
	basic_string<_Elem, _Traits, _Alloc> _Ans;
	_Ans.reserve(_Left.size() + _Right.size());
	_Ans += _Left;
	_Ans += _Right;
	return (_Ans);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		_In_z_ const _Elem * const _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// return NTCTS + string
	using _String_type = basic_string<_Elem, _Traits, _Alloc>;
	using _Size_type = typename _String_type::size_type;
	_String_type _Ans;
	_Ans.reserve(_Convert_size<_Size_type>(_Traits::length(_Left) + _Right.size()));
	_Ans += _Left;
	_Ans += _Right;
	return (_Ans);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		const _Elem _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// return character + string
	basic_string<_Elem, _Traits, _Alloc> _Ans;
	_Ans.reserve(1 + _Right.size());
	_Ans += _Left;
	_Ans += _Right;
	return (_Ans);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		_In_z_ const _Elem * const _Right)
{	// return string + NTCTS
	using _String_type = basic_string<_Elem, _Traits, _Alloc>;
	using _Size_type = typename _String_type::size_type;
	_String_type _Ans;
	_Ans.reserve(_Convert_size<_Size_type>(_Left.size() + _Traits::length(_Right)));
	_Ans += _Left;
	_Ans += _Right;
	return (_Ans);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		const _Elem _Right)
{	// return string + character
	basic_string<_Elem, _Traits, _Alloc> _Ans;
	_Ans.reserve(_Left.size() + 1);
	_Ans += _Left;
	_Ans += _Right;
	return (_Ans);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		basic_string<_Elem, _Traits, _Alloc>&& _Right)
{	// return string + string
	return (_STD move(_Right.insert(0, _Left)));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		basic_string<_Elem, _Traits, _Alloc>&& _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// return string + string
	return (_STD move(_Left.append(_Right)));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		basic_string<_Elem, _Traits, _Alloc>&& _Left,
		basic_string<_Elem, _Traits, _Alloc>&& _Right)
{	// return string + string
	if (_Right.size() <= _Left.capacity() - _Left.size()
		|| _Right.capacity() - _Right.size() < _Left.size())
		return (_STD move(_Left.append(_Right)));
	else
		return (_STD move(_Right.insert(0, _Left)));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		_In_z_ const _Elem * const _Left,
		basic_string<_Elem, _Traits, _Alloc>&& _Right)
{	// return NTCTS + string
	return (_STD move(_Right.insert(0, _Left)));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		const _Elem _Left,
		basic_string<_Elem, _Traits, _Alloc>&& _Right)
{	// return character + string
	using size_type = typename allocator_traits<_Alloc>::size_type;
	return (_STD move(_Right.insert(static_cast<size_type>(0), static_cast<size_type>(1), _Left)));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		basic_string<_Elem, _Traits, _Alloc>&& _Left,
		_In_z_ const _Elem * const _Right)
{	// return string + NTCTS
	return (_STD move(_Left.append(_Right)));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	basic_string<_Elem, _Traits, _Alloc> operator+(
		basic_string<_Elem, _Traits, _Alloc>&& _Left,
		const _Elem _Right)
{	// return string + character
	_Left.push_back(_Right);
	return (_STD move(_Left));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator==(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right) _NOEXCEPT
{	// test for string equality
	return (_Left._Equal(_Right));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator==(
		_In_z_ const _Elem * const _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// test for NTCTS vs. string equality
	return (_Right._Equal(_Left));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator==(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		_In_z_ const _Elem * const _Right)
{	// test for string vs. NTCTS equality
	return (_Left._Equal(_Right));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator!=(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right) _NOEXCEPT
{	// test for string inequality
	return (!(_Left == _Right));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator!=(
		_In_z_ const _Elem * const _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// test for NTCTS vs. string inequality
	return (!(_Left == _Right));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator!=(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		_In_z_ const _Elem * const _Right)
{	// test for string vs. NTCTS inequality
	return (!(_Left == _Right));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator<(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right) _NOEXCEPT
{	// test if string < string
	return (_Left.compare(_Right) < 0);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator<(
		_In_z_ const _Elem * const _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// test if NTCTS < string
	return (_Right.compare(_Left) > 0);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator<(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		_In_z_ const _Elem * const _Right)
{	// test if string < NTCTS
	return (_Left.compare(_Right) < 0);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator>(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right) _NOEXCEPT
{	// test if string > string
	return (_Right < _Left);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator>(
		_In_z_ const _Elem * const _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// test if NTCTS > string
	return (_Right < _Left);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator>(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		_In_z_ const _Elem * const _Right)
{	// test if string > NTCTS
	return (_Right < _Left);
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator<=(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right) _NOEXCEPT
{	// test if string <= string
	return (!(_Right < _Left));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator<=(
		_In_z_ const _Elem * const _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// test if NTCTS <= string
	return (!(_Right < _Left));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator<=(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		_In_z_ const _Elem * const _Right)
{	// test if string <= NTCTS
	return (!(_Right < _Left));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator>=(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right) _NOEXCEPT
{	// test if string >= string
	return (!(_Left < _Right));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator>=(
		_In_z_ const _Elem * const _Left,
		const basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// test if NTCTS >= string
	return (!(_Left < _Right));
}

template<class _Elem,
	class _Traits,
	class _Alloc> inline
	bool operator>=(
		const basic_string<_Elem, _Traits, _Alloc>& _Left,
		_In_z_ const _Elem * const _Right)
{	// test if string >= NTCTS
	return (!(_Left < _Right));
}

using string = basic_string<char, char_traits<char>, allocator<char>>;
using wstring = basic_string<wchar_t, char_traits<wchar_t>, allocator<wchar_t>>;
using u16string = basic_string<char16_t, char_traits<char16_t>, allocator<char16_t>>;
using u32string = basic_string<char32_t, char_traits<char32_t>, allocator<char32_t>>;

// STRUCT TEMPLATE SPECIALIZATION hash
template<class _Elem,
	class _Traits,
	class _Alloc>
	struct hash<basic_string<_Elem, _Traits, _Alloc>>
{	// hash functor for basic_string
	_CXX17_DEPRECATE_ADAPTOR_TYPEDEFS typedef basic_string<_Elem, _Traits, _Alloc> argument_type;
	_CXX17_DEPRECATE_ADAPTOR_TYPEDEFS typedef size_t result_type;

	size_t operator()(const basic_string<_Elem, _Traits, _Alloc>& _Keyval) const _NOEXCEPT
	{	// hash _Keyval to size_t value by pseudorandomizing transform
		return (_Hash_array_representation(_Keyval.c_str(), _Keyval.size()));
	}
};
_STD_END

#pragma pop_macro("new")
#pragma warning(pop)
#pragma pack(pop)
#endif /* RC_INVOKED */
#endif /* _XSTRING_ */

/*
* Copyright (c) by P.J. Plauger. All rights reserved.
* Consult your license regarding permissions and restrictions.
V6.50:0009 */
