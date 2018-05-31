namespace CSharpLibs.Encoders
{
  static class ASCIIEncoder
  {

    public static byte[] GetBytes(string text)
    {
      byte[] result = new byte[text.Length];

      for (int t = 0; t < text.Length; t++)
      {
        switch (text[t])
        {
          case ' ': result[t] = 32; break; // 
          case '!': result[t] = 33; break; // !
          case '"': result[t] = 34; break; // "
          case '#': result[t] = 35; break; // #
          case '$': result[t] = 36; break; // $
          case '%': result[t] = 37; break; // %
          case '&': result[t] = 38; break; // &
          case '\'': result[t] = 39; break; // '
          case '(': result[t] = 40; break; // (
          case ')': result[t] = 41; break; // )
          case '*': result[t] = 42; break; // *
          case '+': result[t] = 43; break; // +
          case ',': result[t] = 44; break; // ,
          case '-': result[t] = 45; break; // -
          case '.': result[t] = 46; break; // .
          case '/': result[t] = 47; break; // /

          case '0': result[t] = 48; break; // 0
          case '1': result[t] = 49; break; // 1
          case '2': result[t] = 50; break; // 2
          case '3': result[t] = 51; break; // 3
          case '4': result[t] = 52; break; // 4
          case '5': result[t] = 53; break; // 5
          case '6': result[t] = 54; break; // 6
          case '7': result[t] = 55; break; // 7
          case '8': result[t] = 56; break; // 8
          case '9': result[t] = 57; break; // 9
          case ':': result[t] = 58; break; // :
          case ';': result[t] = 59; break; // ;
          case '<': result[t] = 60; break; // <
          case '=': result[t] = 61; break; // =
          case '>': result[t] = 62; break; // >
          // case '?': result[t] = 63; break; // ? The questionmark is used as default character for missing encoding

          case '@': result[t] = 64; break; // @
          case 'A': result[t] = 65; break; // A
          case 'B': result[t] = 66; break; // B
          case 'C': result[t] = 67; break; // C
          case 'D': result[t] = 68; break; // D
          case 'E': result[t] = 69; break; // E
          case 'F': result[t] = 70; break; // F
          case 'G': result[t] = 71; break; // G
          case 'H': result[t] = 72; break; // H
          case 'I': result[t] = 73; break; // I
          case 'J': result[t] = 74; break; // J
          case 'K': result[t] = 75; break; // K
          case 'L': result[t] = 76; break; // L
          case 'M': result[t] = 77; break; // M
          case 'N': result[t] = 78; break; // N
          case 'O': result[t] = 79; break; // O

          case 'P': result[t] = 80; break; // P
          case 'Q': result[t] = 81; break; // Q
          case 'R': result[t] = 82; break; // R
          case 'S': result[t] = 83; break; // S
          case 'T': result[t] = 84; break; // T
          case 'U': result[t] = 85; break; // U
          case 'V': result[t] = 86; break; // V
          case 'W': result[t] = 87; break; // W
          case 'X': result[t] = 88; break; // X
          case 'Y': result[t] = 89; break; // Y
          case 'Z': result[t] = 90; break; // Z
          case '[': result[t] = 91; break; // [
          case '\\': result[t] = 92; break; // \
          case ']': result[t] = 93; break; // ]
          case '^': result[t] = 94; break; // ^
          case '_': result[t] = 95; break; // _

          case '`': result[t] = 96; break; // `
          case 'a': result[t] = 97; break; // a
          case 'b': result[t] = 98; break; // b
          case 'c': result[t] = 99; break; // c
          case 'd': result[t] = 100; break; // d
          case 'e': result[t] = 101; break; // e
          case 'f': result[t] = 102; break; // f
          case 'g': result[t] = 103; break; // g
          case 'h': result[t] = 104; break; // h
          case 'i': result[t] = 105; break; // i
          case 'j': result[t] = 106; break; // j
          case 'k': result[t] = 107; break; // k
          case 'l': result[t] = 108; break; // l
          case 'm': result[t] = 109; break; // m
          case 'n': result[t] = 110; break; // n
          case 'o': result[t] = 111; break; // o

          case 'p': result[t] = 112; break; // p
          case 'q': result[t] = 113; break; // q
          case 'r': result[t] = 114; break; // r
          case 's': result[t] = 115; break; // s
          case 't': result[t] = 116; break; // t
          case 'u': result[t] = 117; break; // u
          case 'v': result[t] = 118; break; // v
          case 'w': result[t] = 119; break; // w
          case 'x': result[t] = 120; break; // x
          case 'y': result[t] = 121; break; // y
          case 'z': result[t] = 122; break; // z
          case '{': result[t] = 123; break; // {
          case '|': result[t] = 124; break; // |
          case '}': result[t] = 125; break; // }
          case '~': result[t] = 126; break; // ~
          // case '': result[t] = 127; break; // 

          // Characters from here on, can not be encoded by means of [Alt]+0+number

          case 'Ç': result[t] = 128; break; // Ç
          case 'ü': result[t] = 129; break; // ü
          case 'é': result[t] = 130; break; // é
          case 'â': result[t] = 131; break; // â
          case 'ä': result[t] = 132; break; // ä
          case 'à': result[t] = 133; break; // à
          case 'å': result[t] = 134; break; // å
          case 'ç': result[t] = 135; break; // ç
          case 'ê': result[t] = 136; break; // ê
          case 'ë': result[t] = 137; break; // ë
          case 'è': result[t] = 138; break; // è
          case 'ï': result[t] = 139; break; // ï
          case 'î': result[t] = 140; break; // î
          case 'ì': result[t] = 141; break; // ì
          case 'Ä': result[t] = 142; break; // Ä
          case 'Å': result[t] = 143; break; // Å

          case 'É': result[t] = 144; break; // É
          case 'æ': result[t] = 145; break; // æ
          case 'Æ': result[t] = 146; break; // Æ
          case 'ô': result[t] = 147; break; // ô
          case 'ö': result[t] = 148; break; // ö
          case 'ò': result[t] = 149; break; // ò
          case 'û': result[t] = 150; break; // û
          case 'ù': result[t] = 151; break; // ù
          case 'ÿ': result[t] = 152; break; // ÿ
          case 'Ö': result[t] = 153; break; // Ö
          case 'Ü': result[t] = 154; break; // Ü
          case 'ø': result[t] = 155; break; // ø
          case '£': result[t] = 156; break; // £
          case 'Ø': result[t] = 157; break; // Ø
          case '×': result[t] = 158; break; // ×
          case 'ƒ': result[t] = 159; break; // ƒ

          case 'á': result[t] = 160; break; // á
          case 'í': result[t] = 161; break; // í
          case 'ó': result[t] = 162; break; // ó
          case 'ú': result[t] = 163; break; // ú
          case 'ñ': result[t] = 164; break; // ñ
          case 'Ñ': result[t] = 165; break; // Ñ
          case 'ª': result[t] = 166; break; // ª
          case 'º': result[t] = 167; break; // º
          case '¿': result[t] = 168; break; // ¿
                                            // (R) symbol => 169
                                            // not symbol => 170
          case '½': result[t] = 171; break; // ½
          case '¼': result[t] = 172; break; // ¼
          case '¡': result[t] = 173; break; // ¡
          case '«': result[t] = 174; break; // «
          case '»': result[t] = 175; break; // »

          default: result[t] = 63; break; // All other chars default to: ?
        }
      }

      return result;
    }

  }
}
