namespace DotNetNote.Models
{
    public enum BoardWriteFormType
    {
        Write,  // 글쓰기 모드
        Modify, // 글수정 모드
        Reply   // 댓글모드
    }
    public enum COntentEncodingType
    {
        Text,  // 일반텍스트
        Html, // HTML 입력모드
        Mixed // HTMl입력 + 엔터키 모드

    }
}