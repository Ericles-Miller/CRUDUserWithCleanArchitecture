namespace ReceptionistNameSpace
{
    public class ListReceptionistController {

        ListReceptionistUseCase listReceptionistUseCase;
        public ListReceptionistController(ListReceptionistUseCase listReceptionistUseCase){
            this.listReceptionistUseCase = listReceptionistUseCase;
        }

        public List<Receptionist> handle(){
           var all = listReceptionistUseCase.execute();
           return all;
        }
    }
}