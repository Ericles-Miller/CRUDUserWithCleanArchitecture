 namespace ReceptionistNameSpace
{
  public class CreateReceptionistController{
    CreateReceptionistUseCase createReceptionistUseCase;
    public CreateReceptionistController(CreateReceptionistUseCase createReceptionistUseCase){
      this.createReceptionistUseCase = createReceptionistUseCase;
    }
    
    public void handle(string address, string name, int number) {          
      var receptionists = createReceptionistUseCase.execute( address, name, number);
      Console.WriteLine("Data insert with success!"); // should insert return with json and requidi
    }
  }
}
