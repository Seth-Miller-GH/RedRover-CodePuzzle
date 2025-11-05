import { expect, test } from 'vitest';
import { formatObjectAsString } from '../src/formatter';

test('formats empty object', () => {
    expect(formatObjectAsString({})).toEqual('');
});

test('formats empty object, with sort', () => {
    expect(formatObjectAsString({}, true)).toEqual('');
});

test('formats simple object', () => {
    expect(formatObjectAsString({ a: '', b: '' }))
        .toEqual('- a\n- b\n');
});

test('formats simple object, with sort', () => {
    expect(formatObjectAsString({ b: '', a: '' }, true))
        .toEqual('- a\n- b\n');
});

test('formats complex object', () => {
    expect(formatObjectAsString({ a: '', b: '', c: { d: '', e: { f: '', g: '' }, h: '' }, i: '' }))
        .toEqual('- a\n- b\n- c\n  - d\n  - e\n    - f\n    - g\n  - h\n- i\n');
});

test('formats complex object, with sort', () => {
    expect(formatObjectAsString({ b: '', c: { d: '', h: '', e: { f: '', g: '' } }, i: '', a: '' }, true))
        .toEqual('- a\n- b\n- c\n  - d\n  - e\n    - f\n    - g\n  - h\n- i\n');
});