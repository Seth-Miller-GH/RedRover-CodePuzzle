namespace SethMiller_CSharp.Logic
{
    public static class Parser
    {

        public static ParsedObject ParseString(string src)
        {
            var result = new ParsedObject();

            var inPropName = false;
            var propNameBuffer = "";
            var inObjectDef = false;
            var parenthesisBalance = 0;
            var objectDefBuffer = "";

            foreach (var thisCharacter in src)
            {
                if (inObjectDef) // if building an inner object definition string...
                {
                    objectDefBuffer += thisCharacter; // append the character to the buffer

                    if (thisCharacter == '(') // if on an opening parenthesis, increment the balance count
                    {
                        parenthesisBalance++;
                    }
                    else if (thisCharacter == ')' && --parenthesisBalance == 0) // if on a closing parenthesis and it balances
                    {
                        result[propNameBuffer] = ParseString(objectDefBuffer); // the object definition should be complete, so build it recursively

                        // reset the vars
                        objectDefBuffer = "";
                        propNameBuffer = "";
                        inObjectDef = false;
                        inPropName = false;
                    }

                    continue;
                }

                if (!inPropName) // if not currently building a property name...
                {
                    if (!char.IsLetterOrDigit(thisCharacter)) // if the current character isn't alphanumeric, just ignore it
                    {
                        continue;
                    }
                    else // // if the current character is alphanumeric, start building the property name
                    {
                        inPropName = true;
                        propNameBuffer += thisCharacter;
                        continue;
                    }
                }
                else // if currently building a property name...
                {
                    if (new[] { ',', ')' }.Contains(thisCharacter)) // if the character is name-terminating, complete it
                    {
                        if (propNameBuffer != "")
                        {
                            result[propNameBuffer] = null;
                            propNameBuffer = "";
                        }

                        inPropName = false;
                        continue;
                    }
                    else if (thisCharacter == '(') // if the character is an object-initiator, start building that object definition
                    {
                        inPropName = false;
                        inObjectDef = true;
                        parenthesisBalance = 1;
                        objectDefBuffer += thisCharacter;
                        continue;
                    }

                    // nothing special, add the character and keep going
                    propNameBuffer += thisCharacter;
                }
            }

            return result;
        }
    }
}
