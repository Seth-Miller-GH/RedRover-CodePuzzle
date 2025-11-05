import { ParsedObject } from "./common";

const isCharCodeAlphaNumeric = (characterCode: number) =>
    (characterCode >= 48 && characterCode <= 57) || // 0-9
    (characterCode >= 65 && characterCode <= 90) || // A-Z
    (characterCode >= 97 && characterCode <= 122);  // a-z

export const parseString = (src: string): ParsedObject => {
    const result: ParsedObject = {};

    let inPropName: boolean = false;
    let propNameBuffer: string = '';
    let inObjectDef: boolean = false;
    let parethesisBalance: number = 0;
    let objectDefBuffer: string = '';

    for (let character of src) {

        if (inObjectDef) {
            // if building an inner object definition string...

            objectDefBuffer += character; // append the character to the buffer

            if (character === '(') {
                // if on an opening parenthesis, increment the balance count
                parethesisBalance++;
            } else if (character === ')' && --parethesisBalance === 0) {
                // if on a closing parenthesis and it balances, that should be a complete object... build it recursively
                result[propNameBuffer] = parseString(objectDefBuffer);

                // reset the variables
                objectDefBuffer = '';
                propNameBuffer = '';
                inObjectDef = false;
                inPropName = false;
            }

            continue;
        }

        if (!inPropName) {
            // if not currently building a property name...

            if (!isCharCodeAlphaNumeric(character.charCodeAt(0))) {
                // if the current character isn't alpha-numeric, it isn't valid for property names... just ignore it
                continue;
            } else {
                // start building a property name
                inPropName = true;
                propNameBuffer += character;
                continue;
            }
        } else {
            // if currently building a property name...

            if (character === ',' || character === ')') {
                // if the current character is name-terminating, complete it
                if (propNameBuffer !== '') {
                    result[propNameBuffer] = ''; // empty string, just to build the object shape
                    propNameBuffer = '';
                }
                inPropName = false;
                continue;
            } else if (character === '(') {
                // if the current character is an object-initiator, start building that definition
                inPropName = false;
                inObjectDef = true;
                parethesisBalance = 1;
                objectDefBuffer += character;
                continue;
            }

            // nothing special? add the character to the name and keep going
            propNameBuffer += character;
        }
    }

    return result;
}