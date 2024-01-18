using System;

[System.Serializable]
public class Question
{
	public string QuestionText;

	public string Answer1;
	public string Answer2;
	public string Answer3;
	public string Answer4;
	public int CorrectAnswerId;

	public Question(Question _question)
	{
        this.QuestionText = _question.QuestionText;
        this.Answer1 = _question.Answer1;
        this.Answer2 = _question.Answer2;
        this.Answer3 = _question.Answer3;
        this.Answer4 = _question.Answer4;
        this.CorrectAnswerId = _question.CorrectAnswerId;
    }

	public Question(string questionText, 
		string answer1,
		string answer2,
		string answer3,
		string answer4,
        int correctAnswerId
        )
	{
		this.QuestionText = questionText;
        this.Answer1 = answer1;
        this.Answer2 = answer2;
        this.Answer3 = answer3;
        this.Answer4 = answer4;
        this.CorrectAnswerId = correctAnswerId;
	}

	public bool DoAnswer(int answerId)
	{
		return answerId == CorrectAnswerId;
	}
}
