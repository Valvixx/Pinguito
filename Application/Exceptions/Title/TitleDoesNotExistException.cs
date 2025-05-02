namespace Application.Exceptions.Title;

public class TitleAlreadyExistException(string head) : AppException($"Тайтл с названием {head} уже существует", 409);
