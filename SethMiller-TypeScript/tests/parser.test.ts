import { expect, test } from 'vitest';
import { parseString } from '../src/parser';

test('parses empty string', () => {
    expect(parseString('')).toEqual({});
});

test('parses empty object', () => {
    expect(parseString('()')).toEqual({});
});

test('parses simple string', () => {
    expect(parseString('(a, b)')).toEqual({ a: '', b: '' });
});

test('parses nested string', () => {
    expect(parseString('(a, b, c(d, e), f, g(h, i(j, k)), l)'))
        .toEqual({
            a: '',
            b: '',
            c: {
                d: '',
                e: ''
            },
            f: '',
            g: {
                h: '',
                i: {
                    j: '',
                    k: ''
                }
            },
            l: ''
        });
});

test('parses string with duplicate properties', () => {
    expect(parseString('(a, b, a, c(a, b))'))
        .toEqual({
            a: '',
            b: '',
            c: {
                a: '',
                b: ''
            }
        });
});