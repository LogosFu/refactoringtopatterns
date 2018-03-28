﻿using System;

namespace ComposeMethod.MyWork
{
    public class List
    {
        private bool _readOnly;
        private int _size;
        private Object[] _elements;

        public void add(Object element) {
            if(!_readOnly) {
                int newSize = _size + 1;

                if(newSize > _elements.Length) {
                    Object[] newElements = new Object[_elements.Length + 10];

                    for (int i = 0; i < _size; i++)
                        newElements[i] = _elements[i];

                    _elements = newElements;
                }

                _elements[_size++] = element;
            }
        }
    }
}