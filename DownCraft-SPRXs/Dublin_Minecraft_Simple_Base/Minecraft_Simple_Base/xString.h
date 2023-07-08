// xstring internal header (from <string>)
#ifndef _XSTRING_
#define _XSTRING_
#include <xmemory>
_STD_BEGIN

template<class _Elem,
class _Traits = char_traits<_Elem>,
class _Ax = allocator<_Elem> >
class basic_string;

#if _HAS_TRADITIONAL_ITERATORS

#else /* _HAS_TRADITIONAL_ITERATORS */
// TEMPLATE CLASS _String_const_iterator
template<class _Elem,
class _Traits,
class _Alloc>
class _String_const_iterator
	: public _Ranit<_Elem, typename _Alloc::difference_type,
	typename _Alloc::const_pointer, typename _Alloc::const_reference>
{	// iterator for nonmutable string
public:
	typedef _String_const_iterator<_Elem, _Traits, _Alloc> _Myt;
	typedef basic_string<_Elem, _Traits, _Alloc> _Mystring;

	typedef random_access_iterator_tag iterator_category;
	typedef _Elem value_type;
	typedef typename _Alloc::difference_type difference_type;
	typedef typename _Alloc::const_pointer pointer;
	typedef typename _Alloc::const_reference reference;

	_String_const_iterator()
	{	// construct with null pointer
		_Myptr = 0;
	}

#if _HAS_ITERATOR_DEBUGGING
#define _STRING_CONST_ITERATOR(ptr)	const_iterator(ptr, this)

	_String_const_iterator(pointer _Ptr, const _Container_base *_Pstring)
	{	// construct with pointer _Ptr
		this->_Adopt(_Pstring);
		_Myptr = _Ptr;
	}

#else /* _HAS_ITERATOR_DEBUGGING */
#define _STRING_CONST_ITERATOR(ptr)	const_iterator(ptr)

	_String_const_iterator(pointer _Ptr)
	{	// construct with pointer _Ptr
		_Myptr = _Ptr;
	}
#endif /* _HAS_ITERATOR_DEBUGGING */

	reference operator*() const
	{	// return designated object

#if _HAS_ITERATOR_DEBUGGING
		if (this->_Mycont == 0 || _Myptr == 0
			|| _Myptr < ((_Mystring *)this->_Mycont)->_Myptr()
			|| ((_Mystring *)this->_Mycont)->_Myptr()
			+ ((_Mystring *)this->_Mycont)->_Mysize <= _Myptr)
			_DEBUG_ERROR("string iterator not dereferencable");
#endif /* _HAS_ITERATOR_DEBUGGING */

		return (*_Myptr);
	}

	pointer operator->() const
	{	// return pointer to class object
		return (&**this);
	}

	_Myt& operator++()
	{	// preincrement
		++_Myptr;
		return (*this);
	}

	_Myt operator++(int)
	{	// postincrement
		_Myt _Tmp = *this;
		++*this;
		return (_Tmp);
	}

	_Myt& operator--()
	{	// predecrement
		--_Myptr;
		return (*this);
	}

	_Myt operator--(int)
	{	// postdecrement
		_Myt _Tmp = *this;
		--*this;
		return (_Tmp);
	}

	_Myt& operator+=(difference_type _Off)
	{	// increment by integer
		_Myptr += _Off;
		return (*this);
	}

	_Myt operator+(difference_type _Off) const
	{	// return this + integer
		_Myt _Tmp = *this;
		return (_Tmp += _Off);
	}

	_Myt& operator-=(difference_type _Off)
	{	// decrement by integer
		return (*this += -_Off);
	}

	_Myt operator-(difference_type _Off) const
	{	// return this - integer
		_Myt _Tmp = *this;
		return (_Tmp -= _Off);
	}

	difference_type operator-(const _Myt& _Right) const
	{	// return difference of iterators

#if _HAS_ITERATOR_DEBUGGING
		_Compat(_Right);
#endif /* _HAS_ITERATOR_DEBUGGING */

		return (_Myptr - _Right._Myptr);
	}

	reference operator[](difference_type _Off) const
	{	// subscript
		return (*(*this + _Off));
	}

	bool operator==(const _Myt& _Right) const
	{	// test for iterator equality

#if _HAS_ITERATOR_DEBUGGING
		_Compat(_Right);
#endif /* _HAS_ITERATOR_DEBUGGING */

		return (_Myptr == _Right._Myptr);
	}

	bool operator!=(const _Myt& _Right) const
	{	// test for iterator inequality
		return (!(*this == _Right));
	}

	bool operator<(const _Myt& _Right) const
	{	// test if this < _Right

#if _HAS_ITERATOR_DEBUGGING
		_Compat(_Right);
#endif /* _HAS_ITERATOR_DEBUGGING */

		return (_Myptr < _Right._Myptr);
	}

	bool operator>(const _Myt& _Right) const
	{	// test if this > _Right
		return (_Right < *this);
	}

	bool operator<=(const _Myt& _Right) const
	{	// test if this <= _Right
		return (!(_Right < *this));
	}

	bool operator>=(const _Myt& _Right) const
	{	// test if this >= _Right
		return (!(*this < _Right));
	}

#if _HAS_ITERATOR_DEBUGGING
	void _Compat(const _Myt& _Right) const
	{	// test for compatible iterator pair
		if (this->_Mycont == 0 || this->_Mycont != _Right._Mycont)
			_DEBUG_ERROR("string iterators incompatible");
	}
#endif /* _HAS_ITERATOR_DEBUGGING */

	pointer _Myptr;	// offset of element in string
};

template<class _Elem,
class _Traits,
class _Alloc> inline
	_String_const_iterator<_Elem, _Traits, _Alloc> operator+(
	typename _String_const_iterator<_Elem, _Traits, _Alloc>
	::difference_type _Off,
	_String_const_iterator<_Elem, _Traits, _Alloc> _Next)
{	// add offset to iterator
		return (_Next += _Off);
	}

// TEMPLATE CLASS _String_iterator
template<class _Elem,
class _Traits,
class _Alloc>
class _String_iterator
	: public _String_const_iterator<_Elem, _Traits, _Alloc>
{	// iterator for mutable string
public:
	typedef _String_iterator<_Elem, _Traits, _Alloc> _Myt;
	typedef _String_const_iterator<_Elem, _Traits, _Alloc> _Mybase;

	typedef random_access_iterator_tag iterator_category;
	typedef _Elem value_type;
	typedef typename _Alloc::difference_type difference_type;
	typedef typename _Alloc::pointer pointer;
	typedef typename _Alloc::reference reference;

	_String_iterator()
	{	// construct with null string pointer
	}

#if _HAS_ITERATOR_DEBUGGING
#define _STRING_ITERATOR(ptr)	iterator(ptr, this)

	_String_iterator(pointer _Ptr, const _Container_base *_Pstring)
		: _Mybase(_Ptr, _Pstring)
	{	// construct with pointer _Ptr
	}

#else /* _HAS_ITERATOR_DEBUGGING */
#define _STRING_ITERATOR(ptr)	iterator(ptr)

	_String_iterator(pointer _Ptr)
		: _Mybase(_Ptr)
	{	// construct with pointer _Ptr
	}
#endif /* _HAS_ITERATOR_DEBUGGING */

	reference operator*() const
	{	// return designated object
		return ((reference)**(_Mybase *)this);
	}

	pointer operator->() const
	{	// return pointer to class object
		return (&**this);
	}

	_Myt& operator++()
	{	// preincrement
		++this->_Myptr;
		return (*this);
	}

	_Myt operator++(int)
	{	// postincrement
		_Myt _Tmp = *this;
		++*this;
		return (_Tmp);
	}

	_Myt& operator--()
	{	// predecrement
		--this->_Myptr;
		return (*this);
	}

	_Myt operator--(int)
	{	// postdecrement
		_Myt _Tmp = *this;
		--*this;
		return (_Tmp);
	}

	_Myt& operator+=(difference_type _Off)
	{	// increment by integer
		this->_Myptr += _Off;
		return (*this);
	}

	_Myt operator+(difference_type _Off) const
	{	// return this + integer
		_Myt _Tmp = *this;
		return (_Tmp += _Off);
	}

	_Myt& operator-=(difference_type _Off)
	{	// decrement by integer
		return (*this += -_Off);
	}

	_Myt operator-(difference_type _Off) const
	{	// return this - integer
		_Myt _Tmp = *this;
		return (_Tmp -= _Off);
	}

	difference_type operator-(const _Mybase& _Right) const
	{	// return difference of iterators
		return ((_Mybase)*this - _Right);
	}

	reference operator[](difference_type _Off) const
	{	// subscript
		return (*(*this + _Off));
	}
};

template<class _Elem,
class _Traits,
class _Alloc> inline
	_String_iterator<_Elem, _Traits, _Alloc> operator+(
	typename _String_iterator<_Elem, _Traits, _Alloc>
	::difference_type _Off,
	_String_iterator<_Elem, _Traits, _Alloc> _Next)
{	// add offset to iterator
		return (_Next += _Off);
	}
#endif /* _HAS_TRADITIONAL_ITERATORS */

// CLASS _String_base
class _String_base
	: public _Container_base
{	// ultimate base class for basic_string to hold error reporters
public:
	inline void _Xlen() {}	// report a length_error

	inline void _Xran() {}	// report an out_of_range error
};

// TEMPLATE CLASS _String_val
template<class _Ty,
class _Alloc>
class _String_val
	: public _String_base
{	// base class for basic_string to hold allocator _Alval
protected:
	typedef typename _Alloc::template
		rebind<_Ty>::other _Alty;

	_String_val(_Alty _Al = _Alty())
		: _Alval(_Al)
	{	// construct allocator from _Al
	}

	_Alty _Alval;	// allocator object for strings
};

// TEMPLATE CLASS basic_string
template<class _Elem,
class _Traits,
class _Ax>
class basic_string
	: public _String_val<_Elem, _Ax>
{	// null-terminated transparent array of elements
public:
	typedef basic_string<_Elem, _Traits, _Ax> _Myt;
	typedef _String_val<_Elem, _Ax> _Mybase;
	typedef typename _Mybase::_Alty _Alloc;
	typedef typename _Alloc::size_type size_type;
	typedef typename _Alloc::difference_type _Dift;
	typedef _Dift difference_type;
	typedef typename _Alloc::pointer _Tptr;
	typedef typename _Alloc::const_pointer _Ctptr;
	typedef _Tptr pointer;
	typedef _Ctptr const_pointer;
	typedef typename _Alloc::reference _Reft;
	typedef _Reft reference;
	typedef typename _Alloc::const_reference const_reference;
	typedef typename _Alloc::value_type value_type;

#if _HAS_TRADITIONAL_ITERATORS
#define _STR_ITER_BASE(it)	(it)

	typedef pointer iterator;
	typedef const_pointer const_iterator;

#else /* _HAS_TRADITIONAL_ITERATORS */
#define _STR_ITER_BASE(it)	(it)._Myptr

	typedef _String_iterator<_Elem, _Traits, _Alloc> iterator;
	typedef _String_const_iterator<_Elem, _Traits, _Alloc> const_iterator;

	//	friend class _String_iterator<_Elem, _Traits, _Alloc>;
	friend class _String_const_iterator<_Elem, _Traits, _Alloc>;
#endif /* _HAS_TRADITIONAL_ITERATORS */

	typedef _STD reverse_iterator<iterator> reverse_iterator;
	typedef _STD reverse_iterator<const_iterator> const_reverse_iterator;

	basic_string()
		: _Mybase()
	{	// construct empty string
		_Tidy();
	}

	explicit basic_string(const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct empty string with allocator
		_Tidy();
	}

	basic_string(const _Myt& _Right)
		: _Mybase(_Right._Alval)
	{	// construct by copying _Right
		_Tidy();
		assign(_Right, 0, npos);
	}

	basic_string(const _Myt& _Right, size_type _Roff,

#if defined(__MWERKS__)	/* compiler test */
		size_type _Count = -1)

#else /* __MWERKS__ */
		size_type _Count = npos)
#endif /* __MWERKS__ */

		: _Mybase()
	{	// construct from _Right [_Roff, _Roff + _Count)
			_Tidy();
			assign(_Right, _Roff, _Count);
		}

	basic_string(const _Myt& _Right, size_type _Roff, size_type _Count,
		const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct from _Right [_Roff, _Roff + _Count) with allocator
		_Tidy();
		assign(_Right, _Roff, _Count);
	}

	basic_string(const _Elem *_Ptr, size_type _Count)
		: _Mybase()
	{	// construct from [_Ptr, _Ptr + _Count)
		_Tidy();
		assign(_Ptr, _Count);
	}

	basic_string(const _Elem *_Ptr, size_type _Count, const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct from [_Ptr, _Ptr + _Count) with allocator
		_Tidy();
		assign(_Ptr, _Count);
	}

	basic_string(const _Elem *_Ptr)
		: _Mybase()
	{	// construct from [_Ptr, <null>)
		_Tidy();
		assign(_Ptr);
	}

	basic_string(const _Elem *_Ptr, const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct from [_Ptr, <null>) with allocator
		_Tidy();
		assign(_Ptr);
	}

	basic_string(size_type _Count, _Elem _Ch)
		: _Mybase()
	{	// construct from _Count * _Ch
		_Tidy();
		assign(_Count, _Ch);
	}

	basic_string(size_type _Count, _Elem _Ch, const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct from _Count * _Ch with allocator
		_Tidy();
		assign(_Count, _Ch);
	}

	template<class _It>
	basic_string(_It _First, _It _Last)
		: _Mybase()
	{	// construct from [_First, _Last)
		_Tidy();
		_Construct(_First, _Last, _Iter_cat(_First));
	}

	template<class _It>
	basic_string(_It _First, _It _Last, const _Alloc& _Al)
		: _Mybase(_Al)
	{	// construct from [_First, _Last) with allocator
		_Tidy();
		_Construct(_First, _Last, _Iter_cat(_First));
	}

	template<class _It>
	void _Construct(_It _Count,
		_It _Ch, _Int_iterator_tag)
	{	// initialize from _Count * _Ch
		assign((size_type)_Count, (_Elem)_Ch);
	}

	template<class _It>
	void _Construct(_It _First,
		_It _Last, input_iterator_tag)
	{	// initialize from [_First, _Last), input iterators
		_TRY_BEGIN
		for (; _First != _Last; ++_First)
			append((size_type)1, (_Elem)*_First);
		_CATCH_ALL
			_Tidy(true);
		_RERAISE;
		_CATCH_END
	}

	template<class _It>
	void _Construct(_It _First,
		_It _Last, forward_iterator_tag)
	{	// initialize from [_First, _Last), forward iterators
		_DEBUG_RANGE(_First, _Last);
		size_type _Count = 0;
		_Distance(_First, _Last, _Count);
		reserve(_Count);

		_TRY_BEGIN
		for (; _First != _Last; ++_First)
			append((size_type)1, (_Elem)*_First);
		_CATCH_ALL
			_Tidy(true);
		_RERAISE;
		_CATCH_END
	}

#if _HAS_TRADITIONAL_ITERATORS

#else /* _HAS_TRADITIONAL_ITERATORS */

	basic_string(const_pointer _First, const_pointer _Last)
		: _Mybase()
	{	// construct from [_First, _Last), const pointers
		_DEBUG_RANGE(_First, _Last);
		_Tidy();
		if (_First != _Last)
			assign(&*_First, _Last - _First);
	}
#endif /* _HAS_TRADITIONAL_ITERATORS */

	basic_string(const_iterator _First, const_iterator _Last)
		: _Mybase()
	{	// construct from [_First, _Last), const_iterators
		_DEBUG_RANGE(_First, _Last);
		_Tidy();
		if (_First != _Last)
			assign(&*_First, _Last - _First);
	}

	~basic_string()
	{	// destroy the string
		_Tidy(true);
	}

	typedef _Traits traits_type;
	typedef _Alloc allocator_type;

	static const size_type npos;	// generic bad/missing length/position

	_Myt& operator=(const _Myt& _Right)
	{	// assign _Right
		return (assign(_Right));
	}

	_Myt& operator=(const _Elem *_Ptr)
	{	// assign [_Ptr, <null>)
		return (assign(_Ptr));
	}

	_Myt& operator=(_Elem _Ch)
	{	// assign 1 * _Ch
		return (assign(1, _Ch));
	}

	_Myt& operator+=(const _Myt& _Right)
	{	// append _Right
		return (append(_Right));
	}

	_Myt& operator+=(const _Elem *_Ptr)
	{	// append [_Ptr, <null>)
		return (append(_Ptr));
	}

	_Myt& operator+=(_Elem _Ch)
	{	// append 1 * _Ch
		return (append((size_type)1, _Ch));
	}

	_Myt& append(const _Myt& _Right)
	{	// append _Right
		return (append(_Right, 0, npos));
	}

	_Myt& append(const _Myt& _Right,
		size_type _Roff, size_type _Count)
	{	// append _Right [_Roff, _Roff + _Count)
		if (_Right.size() < _Roff)
			_String_base::_Xran();	// _Roff off end
		size_type _Num = _Right.size() - _Roff;
		if (_Num < _Count)
			_Count = _Num;	// trim _Count to size
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	// result too long

		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
		{	// make room and append new stuff
			_Traits::copy(_Myptr() + _Mysize,
				_Right._Myptr() + _Roff, _Count);
			_Eos(_Num);
		}
		return (*this);
	}

	_Myt& append(const _Elem *_Ptr, size_type _Count)
	{	// append [_Ptr, _Ptr + _Count)
		if (_Inside(_Ptr))
			return (append(*this, _Ptr - _Myptr(), _Count));	// substring
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	// result too long

		size_type _Num;
		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
		{	// make room and append new stuff
			_Traits::copy(_Myptr() + _Mysize, _Ptr, _Count);
			_Eos(_Num);
		}
		return (*this);
	}

	_Myt& append(const _Elem *_Ptr)
	{	// append [_Ptr, <null>)
		return (append(_Ptr, _Traits::length(_Ptr)));
	}

	_Myt& append(size_type _Count, _Elem _Ch)
	{	// append _Count * _Ch
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	// result too long

		size_type _Num;
		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
		{	// make room and append new stuff using assign
			_Chassign(_Mysize, _Count, _Ch);
			_Eos(_Num);
		}
		return (*this);
	}

	template<class _It>
	_Myt& append(_It _First, _It _Last)
	{	// append [_First, _Last)
		return (_Append(_First, _Last, _Iter_cat(_First)));
	}

	template<class _It>
	_Myt& _Append(_It _Count, _It _Ch, _Int_iterator_tag)
	{	// append _Count * _Ch
		return (append((size_type)_Count, (_Elem)_Ch));
	}

	template<class _It>
	_Myt& _Append(_It _First, _It _Last, input_iterator_tag)
	{	// append [_First, _Last), input iterators
		return (replace(end(), end(), _First, _Last));
	}

#if _HAS_TRADITIONAL_ITERATORS

#else /* _HAS_TRADITIONAL_ITERATORS */

	_Myt& append(const_pointer _First, const_pointer _Last)
	{	// append [_First, _Last), const pointers
		return (replace(end(), end(), _First, _Last));
	}
#endif /* _HAS_TRADITIONAL_ITERATORS */

	_Myt& append(const_iterator _First, const_iterator _Last)
	{	// append [_First, _Last), const_iterators
		return (replace(end(), end(), _First, _Last));
	}

	_Myt& assign(const _Myt& _Right)
	{	// assign _Right
		return (assign(_Right, 0, npos));
	}

	_Myt& assign(const _Myt& _Right,
		size_type _Roff, size_type _Count)
	{	// assign _Right [_Roff, _Roff + _Count)
		if (_Right.size() < _Roff)
			_String_base::_Xran();	// _Roff off end
		size_type _Num = _Right.size() - _Roff;
		if (_Count < _Num)
			_Num = _Count;	// trim _Num to size

		if (this == &_Right)
			erase((size_type)(_Roff + _Num)), erase(0, _Roff);	// substring
		else if (_Grow(_Num))
		{	// make room and assign new stuff
			_Traits::copy(_Myptr(), _Right._Myptr() + _Roff, _Num);
			_Eos(_Num);
		}
		return (*this);
	}

	_Myt& assign(const _Elem *_Ptr, size_type _Num)
	{	// assign [_Ptr, _Ptr + _Num)
		if (_Inside(_Ptr))
			return (assign(*this, _Ptr - _Myptr(), _Num));	// substring

		if (_Grow(_Num))
		{	// make room and assign new stuff
			_Traits::copy(_Myptr(), _Ptr, _Num);
			_Eos(_Num);
		}
		return (*this);
	}

	_Myt& assign(const _Elem *_Ptr)
	{	// assign [_Ptr, <null>)
		return (assign(_Ptr, _Traits::length(_Ptr)));
	}

	_Myt& assign(size_type _Count, _Elem _Ch)
	{	// assign _Count * _Ch
		if (_Count == npos)
			_String_base::_Xlen();	// result too long

		if (_Grow(_Count))
		{	// make room and assign new stuff
			_Chassign(0, _Count, _Ch);
			_Eos(_Count);
		}
		return (*this);
	}

	template<class _It>
	_Myt& assign(_It _First, _It _Last)
	{	// assign [First, _Last)
		return (_Assign(_First, _Last, _Iter_cat(_First)));
	}

	template<class _It>
	_Myt& _Assign(_It _Count, _It _Ch, _Int_iterator_tag)
	{	// assign _Count * _Ch
		return (assign((size_type)_Count, (_Elem)_Ch));
	}

	template<class _It>
	_Myt& _Assign(_It _First, _It _Last, input_iterator_tag)
	{	// assign [First, _Last), input iterators
		return (replace(begin(), end(), _First, _Last));
	}

#if _HAS_TRADITIONAL_ITERATORS

#else /* _HAS_TRADITIONAL_ITERATORS */

	_Myt& assign(const_pointer _First, const_pointer _Last)
	{	// assign [First, _Last), const pointers
		return (replace(begin(), end(), _First, _Last));
	}
#endif /* _HAS_TRADITIONAL_ITERATORS */

	_Myt& assign(const_iterator _First, const_iterator _Last)
	{	// assign [First, _Last), const_iterators
		return (replace(begin(), end(), _First, _Last));
	}

	_Myt& insert(size_type _Off, const _Myt& _Right)
	{	// insert _Right at _Off
		return (insert(_Off, _Right, 0, npos));
	}

	_Myt& insert(size_type _Off,
		const _Myt& _Right, size_type _Roff, size_type _Count)
	{	// insert _Right [_Roff, _Roff + _Count) at _Off
		if (_Mysize < _Off || _Right.size() < _Roff)
			_String_base::_Xran();	// _Off or _Roff off end
		size_type _Num = _Right.size() - _Roff;
		if (_Num < _Count)
			_Count = _Num;	// trim _Count to size
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	// result too long

		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
		{	// make room and insert new stuff
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off, _Mysize - _Off);	// empty out hole
			if (this == &_Right)
				_Traits::move(_Myptr() + _Off,
				_Myptr() + (_Off < _Roff ? _Roff + _Count : _Roff),
				_Count);	// substring
			else
				_Traits::copy(_Myptr() + _Off,
				_Right._Myptr() + _Roff, _Count);	// fill hole
			_Eos(_Num);
		}
		return (*this);
	}

	_Myt& insert(size_type _Off,
		const _Elem *_Ptr, size_type _Count)
	{	// insert [_Ptr, _Ptr + _Count) at _Off
		if (_Inside(_Ptr))
			return (insert(_Off, *this,
			_Ptr - _Myptr(), _Count));	// substring
		if (_Mysize < _Off)
			_String_base::_Xran();	// _Off off end
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	// result too long
		size_type _Num;
		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
		{	// make room and insert new stuff
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off, _Mysize - _Off);	// empty out hole
			_Traits::copy(_Myptr() + _Off, _Ptr, _Count);	// fill hole
			_Eos(_Num);
		}
		return (*this);
	}

	_Myt& insert(size_type _Off, const _Elem *_Ptr)
	{	// insert [_Ptr, <null>) at _Off
		return (insert(_Off, _Ptr, _Traits::length(_Ptr)));
	}

	_Myt& insert(size_type _Off,
		size_type _Count, _Elem _Ch)
	{	// insert _Count * _Ch at _Off
		if (_Mysize < _Off)
			_String_base::_Xran();	// _Off off end
		if (npos - _Mysize <= _Count)
			_String_base::_Xlen();	// result too long
		size_type _Num;
		if (0 < _Count && _Grow(_Num = _Mysize + _Count))
		{	// make room and insert new stuff
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off, _Mysize - _Off);	// empty out hole
			_Chassign(_Off, _Count, _Ch);	// fill hole
			_Eos(_Num);
		}
		return (*this);
	}

	iterator insert(iterator _Where)
	{	// insert <null> at _Where
		return (insert(_Where, _Elem()));
	}

	iterator insert(iterator _Where, _Elem _Ch)
	{	// insert _Ch at _Where
		size_type _Off = _Pdif(_Where, begin());
		insert(_Off, 1, _Ch);
		return (begin() + _Off);
	}

	void insert(iterator _Where, size_type _Count, _Elem _Ch)
	{	// insert _Count * _Elem at _Where
		size_type _Off = _Pdif(_Where, begin());
		insert(_Off, _Count, _Ch);
	}

	template<class _It>
	void insert(iterator _Where, _It _First, _It _Last)
	{	// insert [_First, _Last) at _Where
		_Insert(_Where, _First, _Last, _Iter_cat(_First));
	}

	template<class _It>
	void _Insert(iterator _Where, _It _Count, _It _Ch,
		_Int_iterator_tag)
	{	// insert _Count * _Ch at _Where
		insert(_Where, (size_type)_Count, (_Elem)_Ch);
	}

	template<class _It>
	void _Insert(iterator _Where, _It _First, _It _Last,
		input_iterator_tag)
	{	// insert [_First, _Last) at _Where, input iterators
		replace(_Where, _Where, _First, _Last);
	}

#if _HAS_TRADITIONAL_ITERATORS

#else /* _HAS_TRADITIONAL_ITERATORS */

	void insert(iterator _Where, const_pointer _First, const_pointer _Last)
	{	// insert [_First, _Last) at _Where, const pointers
		replace(_Where, _Where, _First, _Last);
	}
#endif /* _HAS_TRADITIONAL_ITERATORS */

	void insert(iterator _Where, const_iterator _First, const_iterator _Last)
	{	// insert [_First, _Last) at _Where, const_iterators
		replace(_Where, _Where, _First, _Last);
	}

	_Myt& erase(size_type _Off = 0,
		size_type _Count = npos)
	{	// erase elements [_Off, _Off + _Count)
		if (_Mysize < _Off)
			_String_base::_Xran();	// _Off off end
		if (_Mysize - _Off < _Count)
			_Count = _Mysize - _Off;	// trim _Count
		if (0 < _Count)
		{	// move elements down
			_Traits::move(_Myptr() + _Off, _Myptr() + _Off + _Count,
				_Mysize - _Off - _Count);
			size_type _Newsize = _Mysize - _Count;
			_Eos(_Newsize);
		}
		return (*this);
	}

	iterator erase(iterator _Where)
	{	// erase element at _Where
		size_type _Count = _Pdif(_Where, begin());
		erase(_Count, 1);
		return (_STRING_ITERATOR(_Myptr() + _Count));
	}

	iterator erase(iterator _First, iterator _Last)
	{	// erase substring [_First, _Last)
		size_type _Count = _Pdif(_First, begin());
		erase(_Count, _Pdif(_Last, _First));
		return (_STRING_ITERATOR(_Myptr() + _Count));
	}

	void clear()
	{	// erase all
		erase(begin(), end());
	}

	_Myt& replace(size_type _Off, size_type _N0, const _Myt& _Right)
	{	// replace [_Off, _Off + _N0) with _Right
		return (replace(_Off, _N0, _Right, 0, npos));
	}

	_Myt& replace(size_type _Off,
		size_type _N0, const _Myt& _Right, size_type _Roff, size_type _Count)
	{	// replace [_Off, _Off + _N0) with _Right [_Roff, _Roff + _Count)
		if (_Mysize < _Off || _Right.size() < _Roff)
			_String_base::_Xran();	// _Off or _Roff off end
		if (_Mysize - _Off < _N0)
			_N0 = _Mysize - _Off;	// trim _N0 to size
		size_type _Num = _Right.size() - _Roff;
		if (_Num < _Count)
			_Count = _Num;	// trim _Count to size
		if (npos - _Count <= _Mysize - _N0)
			_String_base::_Xlen();	// result too long

		size_type _Nm = _Mysize - _N0 - _Off;	// length of preserved tail
		size_type _Newsize = _Mysize + _Count - _N0;
		if (_Mysize < _Newsize)
			_Grow(_Newsize);

		if (this != &_Right)
		{	// no overlap, just move down and copy in new stuff
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	// empty hole
			_Traits::copy(_Myptr() + _Off,
				_Right._Myptr() + _Roff, _Count);	// fill hole
		}
		else if (_Count <= _N0)
		{	// hole doesn't get larger, just copy in substring
			_Traits::move(_Myptr() + _Off,
				_Myptr() + _Roff, _Count);	// fill hole
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	// move tail down
		}
		else if (_Roff <= _Off)
		{	// hole gets larger, substring begins before hole
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	// move tail down
			_Traits::move(_Myptr() + _Off,
				_Myptr() + _Roff, _Count);	// fill hole
		}
		else if (_Off + _N0 <= _Roff)
		{	// hole gets larger, substring begins after hole
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	// move tail down
			_Traits::move(_Myptr() + _Off,
				_Myptr() + (_Roff + _Count - _N0), _Count);	// fill hole
		}
		else
		{	// hole gets larger, substring begins in hole
			_Traits::move(_Myptr() + _Off,
				_Myptr() + _Roff, _N0);	// fill old hole
			_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	// move tail down
			_Traits::move(_Myptr() + _Off + _N0, _Myptr() + _Roff + _Count,
				_Count - _N0);	// fill rest of new hole
		}

		_Eos(_Newsize);
		return (*this);
	}

	_Myt& replace(size_type _Off,
		size_type _N0, const _Elem *_Ptr, size_type _Count)
	{	// replace [_Off, _Off + _N0) with [_Ptr, _Ptr + _Count)
		if (_Inside(_Ptr))
			return (replace(_Off, _N0, *this,
			_Ptr - _Myptr(), _Count));	// substring, replace carefully
		if (_Mysize < _Off)
			_String_base::_Xran();	// _Off off end
		if (_Mysize - _Off < _N0)
			_N0 = _Mysize - _Off;	// trim _N0 to size
		if (npos - _Count <= _Mysize - _N0)
			_String_base::_Xlen();	// result too long
		size_type _Nm = _Mysize - _N0 - _Off;

		if (_Count < _N0)
			_Traits::move(_Myptr() + _Off + _Count,
			_Myptr() + _Off + _N0, _Nm);	// smaller hole, move tail up
		size_type _Num;
		if ((0 < _Count || 0 < _N0) && _Grow(_Num = _Mysize + _Count - _N0))
		{	// make room and rearrange
			if (_N0 < _Count)
				_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	// move tail down
			_Traits::copy(_Myptr() + _Off, _Ptr, _Count);	// fill hole
			_Eos(_Num);
		}
		return (*this);
	}

	_Myt& replace(size_type _Off, size_type _N0, const _Elem *_Ptr)
	{	// replace [_Off, _Off + _N0) with [_Ptr, <null>)
		return (replace(_Off, _N0, _Ptr, _Traits::length(_Ptr)));
	}

	_Myt& replace(size_type _Off,
		size_type _N0, size_type _Count, _Elem _Ch)
	{	// replace [_Off, _Off + _N0) with _Count * _Ch
		if (_Mysize < _Off)
			_String_base::_Xran();	// _Off off end
		if (_Mysize - _Off < _N0)
			_N0 = _Mysize - _Off;	// trim _N0 to size
		if (npos - _Count <= _Mysize - _N0)
			_String_base::_Xlen();	// result too long
		size_type _Nm = _Mysize - _N0 - _Off;

		if (_Count < _N0)
			_Traits::move(_Myptr() + _Off + _Count,
			_Myptr() + _Off + _N0, _Nm);	// smaller hole, move tail up
		size_type _Num;
		if ((0 < _Count || 0 < _N0) && _Grow(_Num = _Mysize + _Count - _N0))
		{	// make room and rearrange
			if (_N0 < _Count)
				_Traits::move(_Myptr() + _Off + _Count,
				_Myptr() + _Off + _N0, _Nm);	// move tail down
			_Chassign(_Off, _Count, _Ch);	// fill hole
			_Eos(_Num);
		}
		return (*this);
	}

	_Myt& replace(iterator _First, iterator _Last, const _Myt& _Right)
	{	// replace [_First, _Last) with _Right
		return (replace(
			_Pdif(_First, begin()), _Pdif(_Last, _First), _Right));
	}

	_Myt& replace(iterator _First, iterator _Last, const _Elem *_Ptr,
		size_type _Count)
	{	// replace [_First, _Last) with [_Ptr, _Ptr + _Count)
		return (replace(
			_Pdif(_First, begin()), _Pdif(_Last, _First), _Ptr, _Count));
	}

	_Myt& replace(iterator _First, iterator _Last, const _Elem *_Ptr)
	{	// replace [_First, _Last) with [_Ptr, <null>)
		return (replace(
			_Pdif(_First, begin()), _Pdif(_Last, _First), _Ptr));
	}

	_Myt& replace(iterator _First, iterator _Last,
		size_type _Count, _Elem _Ch)
	{	// replace [_First, _Last) with _Count * _Ch
		return (replace(
			_Pdif(_First, begin()), _Pdif(_Last, _First), _Count, _Ch));
	}

	template<class _It>
	_Myt& replace(iterator _First, iterator _Last,
		_It _First2, _It _Last2)
	{	// replace [_First, _Last) with [_First2, _Last2)
		return (_Replace(_First, _Last,
			_First2, _Last2, _Iter_cat(_First2)));
	}

	template<class _It>
	_Myt& _Replace(iterator _First, iterator _Last,
		_It _Count, _It _Ch, _Int_iterator_tag)
	{	// replace [_First, _Last) with _Count * _Ch
		return (replace(_First, _Last, (size_type)_Count, (_Elem)_Ch));
	}

	template<class _It>
	_Myt& _Replace(iterator _First, iterator _Last,
		_It _First2, _It _Last2, input_iterator_tag)
	{	// replace [_First, _Last) with [_First2, _Last2), input iterators
		_Myt _Right(_First2, _Last2);
		replace(_First, _Last, _Right);
		return (*this);
	}

#if _HAS_TRADITIONAL_ITERATORS

#else /* _HAS_TRADITIONAL_ITERATORS */

	_Myt& replace(iterator _First, iterator _Last,
		const_pointer _First2, const_pointer _Last2)
	{	// replace [_First, _Last) with [_First2, _Last2), const pointers
		if (_First2 == _Last2)
			erase(_Pdif(_First, begin()), _Pdif(_Last, _First));
		else
			replace(_Pdif(_First, begin()), _Pdif(_Last, _First),
			&*_First2, _Last2 - _First2);
		return (*this);
	}
#endif /* _HAS_TRADITIONAL_ITERATORS */

	_Myt& replace(iterator _First, iterator _Last,
		const_iterator _First2, const_iterator _Last2)
	{	// replace [_First, _Last) with [_First2, _Last2), const_iterators
		if (_First2 == _Last2)
			erase(_Pdif(_First, begin()), _Pdif(_Last, _First));
		else
			replace(_Pdif(_First, begin()), _Pdif(_Last, _First),
			&*_First2, _Last2 - _First2);
		return (*this);
	}

	iterator begin()
	{	// return iterator for beginning of mutable sequence
		return (_STRING_ITERATOR(_Myptr()));
	}

	const_iterator begin() const
	{	// return iterator for beginning of nonmutable sequence
		return (_STRING_CONST_ITERATOR(_Myptr()));
	}

	iterator end()
	{	// return iterator for end of mutable sequence
		return (_STRING_ITERATOR(_Myptr() + _Mysize));
	}

	const_iterator end() const
	{	// return iterator for end of nonmutable sequence
		return (_STRING_CONST_ITERATOR(_Myptr() + _Mysize));
	}

	reverse_iterator rbegin()
	{	// return iterator for beginning of reversed mutable sequence
		return (reverse_iterator(end()));
	}

	const_reverse_iterator rbegin() const
	{	// return iterator for beginning of reversed nonmutable sequence
		return (const_reverse_iterator(end()));
	}

	reverse_iterator rend()
	{	// return iterator for end of reversed mutable sequence
		return (reverse_iterator(begin()));
	}

	const_reverse_iterator rend() const
	{	// return iterator for end of reversed nonmutable sequence
		return (const_reverse_iterator(begin()));
	}

	reference at(size_type _Off)
	{	// subscript mutable sequence with checking
		if (_Mysize <= _Off)
			_String_base::_Xran();	// _Off off end
		return (_Myptr()[_Off]);
	}

	const_reference at(size_type _Off) const
	{	// subscript nonmutable sequence with checking
		if (_Mysize <= _Off)
			_String_base::_Xran();	// _Off off end
		return (_Myptr()[_Off]);
	}

	reference operator[](size_type _Off)
	{	// subscript mutable sequence

#if _HAS_ITERATOR_DEBUGGING
		if (_Mysize <= _Off)
			_DEBUG_ERROR("string subscript out of range");
#endif /* _HAS_ITERATOR_DEBUGGING */

		return (_Myptr()[_Off]);
	}

	const_reference operator[](size_type _Off) const
	{	// subscript nonmutable sequence

#if _HAS_ITERATOR_DEBUGGING
		if (_Mysize < _Off)	// sic
			_DEBUG_ERROR("string subscript out of range");
#endif /* _HAS_ITERATOR_DEBUGGING */

		return (_Myptr()[_Off]);
	}

	void push_back(_Elem _Ch)
	{	// insert element at end
		insert(end(), _Ch);
	}

	const _Elem *c_str() const
	{	// return pointer to null-terminated nonmutable array
		return (_Myptr());
	}

	const _Elem *data() const
	{	// return pointer to nonmutable array
		return (c_str());
	}

	size_type length() const
	{	// return length of sequence
		return (_Mysize);
	}

	size_type size() const
	{	// return length of sequence
		return (_Mysize);
	}

	size_type max_size() const
	{	// return maximum possible length of sequence
		size_type _Num = _Mybase::_Alval.max_size();
		return (_Num <= 1 ? 1 : _Num - 1);
	}

	void resize(size_type _Newsize)
	{	// determine new length, padding with null elements as needed
		resize(_Newsize, _Elem());
	}

	void resize(size_type _Newsize, _Elem _Ch)
	{	// determine new length, padding with _Ch elements as needed
		if (_Newsize <= _Mysize)
			erase(_Newsize);
		else
			append(_Newsize - _Mysize, _Ch);
	}

	size_type capacity() const
	{	// return current length of allocated storage
		return (_Myres);
	}

	void reserve(size_type _Newcap = 0)
	{	// determine new minimum length of allocated storage
		if (_Mysize <= _Newcap && _Myres != _Newcap)
		{	// change reservation
			size_type _Size = _Mysize;
			if (_Grow(_Newcap, true))
				_Eos(_Size);
		}
	}

	bool empty() const
	{	// test if sequence is empty
		return (_Mysize == 0);
	}

	size_type copy(_Elem *_Ptr,
		size_type _Count, size_type _Off = 0) const
	{	// copy [_Off, _Off + _Count) to [_Ptr, _Ptr + _Count)
		_DEBUG_POINTER(_Ptr);
		if (_Mysize < _Off)
			_String_base::_Xran();	// _Off off end
		if (_Mysize - _Off < _Count)
			_Count = _Mysize - _Off;
		_Traits::copy(_Ptr, _Myptr() + _Off, _Count);
		return (_Count);
	}

	void swap(_Myt& _Right)
	{	// exchange contents with _Right
		if (_Mybase::_Alval == _Right._Alval)
		{	// same allocator, swap control information

#if _HAS_ITERATOR_DEBUGGING
			this->_Swap_all(_Right);
#endif /* _HAS_ITERATOR_DEBUGGING */

			_Bxty _Tbx = _Bx;
			_Bx = _Right._Bx, _Right._Bx = _Tbx;

			size_type _Tlen = _Mysize;
			_Mysize = _Right._Mysize, _Right._Mysize = _Tlen;

			size_type _Tres = _Myres;
			_Myres = _Right._Myres, _Right._Myres = _Tres;
		}
		else
		{	// different allocator, do multiple assigns
			_Myt _Tmp = *this; *this = _Right, _Right = _Tmp;
		}
	}

	size_type find(const _Myt& _Right, size_type _Off = 0) const
	{	// look for _Right beginnng at or after _Off
		return (find(_Right._Myptr(), _Off, _Right.size()));
	}

	size_type find(const _Elem *_Ptr,
		size_type _Off, size_type _Count) const
	{	// look for [_Ptr, _Ptr + _Count) beginnng at or after _Off
		_DEBUG_POINTER(_Ptr);
		if (_Count == 0 && _Off <= _Mysize)
			return (_Off);	// null string always matches (if inside string)

		size_type _Nm;
		if (_Off < _Mysize && _Count <= (_Nm = _Mysize - _Off))
		{	// room for match, look for it
			const _Elem *_Uptr, *_Vptr;
			for (_Nm -= _Count - 1, _Vptr = _Myptr() + _Off;
				(_Uptr = _Traits::find(_Vptr, _Nm, *_Ptr)) != 0;
				_Nm -= _Uptr - _Vptr + 1, _Vptr = _Uptr + 1)
			if (_Traits::compare(_Uptr, _Ptr, _Count) == 0)
				return (_Uptr - _Myptr());	// found a match
		}

		return (npos);	// no match
	}

	size_type find(const _Elem *_Ptr, size_type _Off = 0) const
	{	// look for [_Ptr, <null>) beginnng at or after _Off
		return (find(_Ptr, _Off, _Traits::length(_Ptr)));
	}

	size_type find(_Elem _Ch, size_type _Off = 0) const
	{	// look for _Ch at or after _Off
		return (find((const _Elem *)&_Ch, _Off, 1));
	}

	size_type rfind(const _Myt& _Right, size_type _Off = npos) const
	{	// look for _Right beginning before _Off
		return (rfind(_Right._Myptr(), _Off, _Right.size()));
	}

	size_type rfind(const _Elem *_Ptr,
		size_type _Off, size_type _Count) const
	{	// look for [_Ptr, _Ptr + _Count) beginning before _Off
		_DEBUG_POINTER(_Ptr);
		if (_Count == 0)
			return (_Off < _Mysize ? _Off : _Mysize);	// null always matches
		if (_Count <= _Mysize)
		{	// room for match, look for it
			const _Elem *_Uptr = _Myptr() +
				(_Off < _Mysize - _Count ? _Off : _Mysize - _Count);
			for (;; --_Uptr)
			if (_Traits::eq(*_Uptr, *_Ptr)
				&& _Traits::compare(_Uptr, _Ptr, _Count) == 0)
				return (_Uptr - _Myptr());	// found a match
			else if (_Uptr == _Myptr())
				break;	// at beginning, no more chance for match
		}

		return (npos);	// no match
	}

	size_type rfind(const _Elem *_Ptr, size_type _Off = npos) const
	{	// look for [_Ptr, <null>) beginning before _Off
		return (rfind(_Ptr, _Off, _Traits::length(_Ptr)));
	}

	size_type rfind(_Elem _Ch, size_type _Off = npos) const
	{	// look for _Ch before _Off
		return (rfind((const _Elem *)&_Ch, _Off, 1));
	}

	size_type find_first_of(const _Myt& _Right,
		size_type _Off = 0) const
	{	// look for one of _Right at or after _Off
		return (find_first_of(_Right._Myptr(), _Off, _Right.size()));
	}

	size_type find_first_of(const _Elem *_Ptr,
		size_type _Off, size_type _Count) const
	{	// look for one of [_Ptr, _Ptr + _Count) at or after _Off
		_DEBUG_POINTER(_Ptr);
		if (0 < _Count && _Off < _Mysize)
		{	// room for match, look for it
			const _Elem *const _Vptr = _Myptr() + _Mysize;
			for (const _Elem *_Uptr = _Myptr() + _Off; _Uptr < _Vptr; ++_Uptr)
			if (_Traits::find(_Ptr, _Count, *_Uptr) != 0)
				return (_Uptr - _Myptr());	// found a match
		}

		return (npos);	// no match
	}

	size_type find_first_of(const _Elem *_Ptr, size_type _Off = 0) const
	{	// look for one of [_Ptr, <null>) at or after _Off
		return (find_first_of(_Ptr, _Off, _Traits::length(_Ptr)));
	}

	size_type find_first_of(_Elem _Ch, size_type _Off = 0) const
	{	// look for _Ch at or after _Off
		return (find((const _Elem *)&_Ch, _Off, 1));
	}

	size_type find_last_of(const _Myt& _Right,
		size_type _Off = npos) const
	{	// look for one of _Right before _Off
		return (find_last_of(_Right._Myptr(), _Off, _Right.size()));
	}

	size_type find_last_of(const _Elem *_Ptr,
		size_type _Off, size_type _Count) const
	{	// look for one of [_Ptr, _Ptr + _Count) before _Off
		_DEBUG_POINTER(_Ptr);
		if (0 < _Count && 0 < _Mysize)
		for (const _Elem *_Uptr = _Myptr()
			+ (_Off < _Mysize ? _Off : _Mysize - 1);; --_Uptr)
		if (_Traits::find(_Ptr, _Count, *_Uptr) != 0)
			return (_Uptr - _Myptr());	// found a match
		else if (_Uptr == _Myptr())
			break;	// at beginning, no more chance for match

		return (npos);	// no match
	}

	size_type find_last_of(const _Elem *_Ptr,
		size_type _Off = npos) const
	{	// look for one of [_Ptr, <null>) before _Off
		return (find_last_of(_Ptr, _Off, _Traits::length(_Ptr)));
	}

	size_type find_last_of(_Elem _Ch, size_type _Off = npos) const
	{	// look for _Ch before _Off
		return (rfind((const _Elem *)&_Ch, _Off, 1));
	}

	size_type find_first_not_of(const _Myt& _Right,
		size_type _Off = 0) const
	{	// look for none of _Right at or after _Off
		return (find_first_not_of(_Right._Myptr(), _Off,
			_Right.size()));
	}

	size_type find_first_not_of(const _Elem *_Ptr,
		size_type _Off, size_type _Count) const
	{	// look for none of [_Ptr, _Ptr + _Count) at or after _Off
		_DEBUG_POINTER(_Ptr);
		if (_Off < _Mysize)
		{	// room for match, look for it
			const _Elem *const _Vptr = _Myptr() + _Mysize;
			for (const _Elem *_Uptr = _Myptr() + _Off; _Uptr < _Vptr; ++_Uptr)
			if (_Traits::find(_Ptr, _Count, *_Uptr) == 0)
				return (_Uptr - _Myptr());
		}
		return (npos);
	}

	size_type find_first_not_of(const _Elem *_Ptr,
		size_type _Off = 0) const
	{	// look for one of [_Ptr, <null>) at or after _Off
		return (find_first_not_of(_Ptr, _Off, _Traits::length(_Ptr)));
	}

	size_type find_first_not_of(_Elem _Ch, size_type _Off = 0) const
	{	// look for non _Ch at or after _Off
		return (find_first_not_of((const _Elem *)&_Ch, _Off, 1));
	}

	size_type find_last_not_of(const _Myt& _Right,
		size_type _Off = npos) const
	{	// look for none of _Right before _Off
		return (find_last_not_of(_Right._Myptr(), _Off, _Right.size()));
	}

	size_type find_last_not_of(const _Elem *_Ptr,
		size_type _Off, size_type _Count) const
	{	// look for none of [_Ptr, _Ptr + _Count) before _Off
		_DEBUG_POINTER(_Ptr);
		if (0 < _Mysize)
		for (const _Elem *_Uptr = _Myptr()
			+ (_Off < _Mysize ? _Off : _Mysize - 1);; --_Uptr)
		if (_Traits::find(_Ptr, _Count, *_Uptr) == 0)
			return (_Uptr - _Myptr());
		else if (_Uptr == _Myptr())
			break;
		return (npos);
	}

	size_type find_last_not_of(const _Elem *_Ptr,
		size_type _Off = npos) const
	{	// look for none of [_Ptr, <null>) before _Off
		return (find_last_not_of(_Ptr, _Off, _Traits::length(_Ptr)));
	}

	size_type find_last_not_of(_Elem _Ch, size_type _Off = npos) const
	{	// look for non _Ch before _Off
		return (find_last_not_of((const _Elem *)&_Ch, _Off, 1));
	}

	_Myt substr(size_type _Off = 0, size_type _Count = npos) const
	{	// return [_Off, _Off + _Count) as new string
		return (_Myt(*this, _Off, _Count));
	}

	int compare(const _Myt& _Right) const
	{	// compare [0, _Mysize) with _Right
		return (compare(0, _Mysize, _Right._Myptr(), _Right.size()));
	}

	int compare(size_type _Off, size_type _N0,
		const _Myt& _Right) const
	{	// compare [_Off, _Off + _N0) with _Right
		return (compare(_Off, _N0, _Right, 0, npos));
	}

	int compare(size_type _Off,
		size_type _N0, const _Myt& _Right,
		size_type _Roff, size_type _Count) const
	{	// compare [_Off, _Off + _N0) with _Right [_Roff, _Roff + _Count)
		if (_Right.size() < _Roff)
			_String_base::_Xran();	// _Off off end
		if (_Right._Mysize - _Roff < _Count)
			_Count = _Right._Mysize - _Roff;	// trim _Count to size
		return (compare(_Off, _N0, _Right._Myptr() + _Roff, _Count));
	}

	int compare(const _Elem *_Ptr) const
	{	// compare [0, _Mysize) with [_Ptr, <null>)
		return (compare(0, _Mysize, _Ptr, _Traits::length(_Ptr)));
	}

	int compare(size_type _Off, size_type _N0, const _Elem *_Ptr) const
	{	// compare [_Off, _Off + _N0) with [_Ptr, <null>)
		return (compare(_Off, _N0, _Ptr, _Traits::length(_Ptr)));
	}

	int compare(size_type _Off,
		size_type _N0, const _Elem *_Ptr, size_type _Count) const
	{	// compare [_Off, _Off + _N0) with [_Ptr, _Ptr + _Count)
		_DEBUG_POINTER(_Ptr);
		if (_Mysize < _Off)
			return 0;
		if (_Mysize - _Off < _N0)
			_N0 = _Mysize - _Off;	// trim _N0 to size

		size_type _Ans = _N0 == 0 ? 0
			: _Traits::compare(_Myptr() + _Off, _Ptr,
			_N0 < _Count ? _N0 : _Count);
		return (_Ans != 0 ? (int)_Ans : _N0 < _Count ? -1
			: _N0 == _Count ? 0 : +1);
	}

	allocator_type get_allocator() const
	{	// return allocator object for values
		return (_Mybase::_Alval);
	}

	enum
	{	// length of internal buffer, [1, 16]
		_BUF_SIZE = 16 / sizeof (_Elem) < 1 ? 1
		: 16 / sizeof(_Elem)
	};

protected:
	enum
	{	// roundup mask for allocated buffers, [0, 15]
		_ALLOC_MASK = sizeof (_Elem) <= 1 ? 15
		: sizeof (_Elem) <= 2 ? 7
		: sizeof (_Elem) <= 4 ? 3
		: sizeof (_Elem) <= 8 ? 1 : 0
	};

	void _Chassign(size_type _Off, size_type _Count, _Elem _Ch)
	{	// assign _Count copies of _Ch beginning at _Off 
		if (_Count == 1)
			_Traits::assign(*(_Myptr() + _Off), _Ch);
		else
			_Traits::assign(_Myptr() + _Off, _Count, _Ch);
	}

	void _Copy(size_type _Newsize, size_type _Oldlen)
	{	// copy _Oldlen elements to newly allocated buffer
		size_type _Newres = _Newsize | _ALLOC_MASK;
		if (max_size() < _Newres)
			_Newres = _Newsize;	// undo roundup if too big
		else if (_Newres / 3 < _Myres / 2
			&& _Myres <= max_size() - _Myres / 2)
			_Newres = _Myres + _Myres / 2;	// grow exponentially if possible
		_Elem *_Ptr;

		_TRY_BEGIN
			_Ptr = _Mybase::_Alval.allocate(_Newres + 1);
		_CATCH_ALL
			_Newres = _Newsize;	// allocation failed, undo roundup and retry
		_TRY_BEGIN
			_Ptr = _Mybase::_Alval.allocate(_Newres + 1);
		_CATCH_ALL
			_Tidy(true);	// failed again, discard storage and reraise
		_RERAISE;
		_CATCH_END
			_CATCH_END

		if (0 < _Oldlen)
			_Traits::copy(_Ptr, _Myptr(), _Oldlen);	// copy existing elements
		_Tidy(true);
		_Bx._Ptr = _Ptr;
		_Myres = _Newres;
		_Eos(_Oldlen);
	}

	void _Eos(size_type _Newsize)
	{	// set new length and null terminator
		_Traits::assign(_Myptr()[_Mysize = _Newsize], _Elem());
	}

	bool _Grow(size_type _Newsize,
		bool _Trim = false)
	{	// ensure buffer is big enough, trim to size if _Trim is true
		if (max_size() < _Newsize)
			_String_base::_Xlen();	// result too long
		if (_Myres < _Newsize)
			_Copy(_Newsize, _Mysize);	// reallocate to grow
		else if (_Trim && _Newsize < _BUF_SIZE)
			_Tidy(true,	// copy and deallocate if trimming to small string
			_Newsize < _Mysize ? _Newsize : _Mysize);
		else if (_Newsize == 0)
			_Eos(0);	// new size is zero, just null terminate
		return (0 < _Newsize);	// return true only if more work to do
	}

	bool _Inside(const _Elem *_Ptr)
	{	// test if _Ptr points inside string
		_DEBUG_POINTER(_Ptr);
		if (_Ptr < _Myptr() || _Myptr() + _Mysize <= _Ptr)
			return (false);	// don't ask
		else
			return (true);
	}

	static size_type _Pdif(const_iterator _P2,
		const_iterator _P1)
	{	// compute safe iterator difference
		return (_STR_ITER_BASE(_P2) == 0 ? 0 : _P2 - _P1);
	}

	void _Tidy(bool _Built = false,
		size_type _Newsize = 0)
	{	// initialize buffer, deallocating any storage
		if (!_Built)
			;
		else if (_BUF_SIZE <= _Myres)
		{	// copy any leftovers to small buffer and deallocate
			_Elem *_Ptr = _Bx._Ptr;
			if (0 < _Newsize)
				_Traits::copy(_Bx._Buf, _Ptr, _Newsize);
			_Mybase::_Alval.deallocate(_Ptr, _Myres + 1);
		}
		_Myres = _BUF_SIZE - 1;
		_Eos(_Newsize);
	}

	union _Bxty
	{	// storage for small buffer or pointer to larger one
		_Elem _Buf[_BUF_SIZE];
		_Elem *_Ptr;
	} _Bx;

	_Elem *_Myptr()
	{	// determine current pointer to buffer for mutable string
		return (_BUF_SIZE <= _Myres ? _Bx._Ptr : _Bx._Buf);
	}

	const _Elem *_Myptr() const
	{	// determine current pointer to buffer for nonmutable string
		return (_BUF_SIZE <= _Myres ? _Bx._Ptr : _Bx._Buf);
	}

	size_type _Mysize;	// current length of string
	size_type _Myres;	// current storage reserved for string
};


// STATIC npos OBJECT
template<class _Elem,
class _Traits,
class _Alloc>
	const typename basic_string<_Elem, _Traits, _Alloc>::size_type
	basic_string<_Elem, _Traits, _Alloc>::npos =
	(typename basic_string<_Elem, _Traits, _Alloc>::size_type)(-1);

// basic_string TEMPLATE OPERATORS
template<class _Elem,
class _Traits,
class _Alloc> inline
	void swap(basic_string<_Elem, _Traits, _Alloc>& _Left,
	basic_string<_Elem, _Traits, _Alloc>& _Right)
{	// swap _Left and _Right strings
		_Left.swap(_Right);
	}

typedef basic_string<char, char_traits<char>, allocator<char> >
string;
typedef basic_string<wchar_t, char_traits<wchar_t>,
	allocator<wchar_t> > wstring;

#ifdef  _DLL

#ifdef __FORCE_INSTANCE
template class allocator<char>;
template class allocator<wchar_t>;
template class _String_val<char, allocator<char> >;
template class _String_val<wchar_t, allocator<wchar_t> >;
template class basic_string<char, char_traits<char>,
	allocator<char> >;
template class basic_string<wchar_t, char_traits<wchar_t>,
	allocator<wchar_t> >;

#ifdef _CRTBLD_NATIVE_WCHAR_T
template class basic_string<unsigned short, char_traits<unsigned short>,
	allocator<unsigned short> >;
#endif /* _CRTBLD_NATIVE_WCHAR_T */

#else /* __FORCE_INSTANCE */
extern template class allocator<char>;
extern template class allocator<wchar_t>;
extern template class _String_val<char, allocator<char> >;
extern template class _String_val<wchar_t, allocator<wchar_t> >;
extern template class basic_string<char, char_traits<char>,
	allocator<char> >;
extern template class basic_string<wchar_t, char_traits<wchar_t>,
	allocator<wchar_t> >;
#endif /* __FORCE_INSTANCE */

#endif /* _DLL */
_STD_END
#endif /* _XSTRING */

/*
* Copyright (c) 1992-2003 by P.J. Plauger.  ALL RIGHTS RESERVED.
* Consult your license regarding permissions and restrictions.
V4.02:0216 */
