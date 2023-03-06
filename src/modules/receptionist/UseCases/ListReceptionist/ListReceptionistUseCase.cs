
namespace ReceptionistNameSpace {
public class ListReceptionistUseCase {
  ReceptionistRepository receptionistRepository;
    public ListReceptionistUseCase(ReceptionistRepository receptionistRepository) {
      this.receptionistRepository = receptionistRepository;
    }
    
    public List<Receptionist> execute() {
      var allReceptionist = receptionistRepository.listReceptionist();
      return allReceptionist;
    }   
  }
}