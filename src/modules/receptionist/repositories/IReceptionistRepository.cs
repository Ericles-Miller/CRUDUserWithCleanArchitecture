namespace ReceptionistNameSpace {
    
    public interface IReceptionistRepository {
        List<Receptionist> createReceptionist(string address, string name,int number);
        bool findByNumber(int number);

        List<Receptionist> listReceptionist();
    }
}
