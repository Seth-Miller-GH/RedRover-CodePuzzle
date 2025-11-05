import { formatObjectAsString } from "./formatter";
import { parseString } from "./parser";

const strValue = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";

console.info('Original string: ', strValue);
console.info('-----');

console.log('Formatted string:');
console.log(formatObjectAsString(parseString(strValue)));

console.log('Sorted formatted string:');
console.log(formatObjectAsString(parseString(strValue), true));