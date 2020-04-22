using System.Collections.Generic;

namespace Shop {

    ///
    // IDAO - Interface Data Access Object - connection to DB
    ///
    public interface IDAO
    {
        void Add_new_record() {}
        void ReadRecord() {}
        void UpdateRecord() {}
        void DeleteRecord() {}
        void ReadTable(string tableName, List<string> requiredColumns) {}
    }
}