import { ParsedObject } from "./common";

const INDENT_SIZE = 2;

export const formatObjectAsString = (obj: ParsedObject, shouldSort: boolean = false, indentationLevel: number = 0): string => {
    let result = '';
    const indent = ' '.repeat(INDENT_SIZE * indentationLevel);

    for (let k of (shouldSort ? Object.keys(obj).sort() : Object.keys(obj))) {
        const nestedObjectResult = typeof (obj[k]) === 'object' ?
            formatObjectAsString(obj[k] as ParsedObject, shouldSort, indentationLevel + 1) :
            '';
        result += `${indent}- ${k}\n${nestedObjectResult}`;
    }

    return result;
}