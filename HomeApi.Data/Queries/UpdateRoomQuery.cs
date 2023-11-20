namespace HomeApi.Data.Queries
{
    /// <summary>
    /// Класс для передачи дополнительных параметров при обновлении инфо о комнате
    /// </summary>
    public class UpdateRoomQuery
    {
        public string NewName { get; }
        public int? NewArea { get; set; }
        public bool? NewGasConnected { get; set; }
        public int? NewVoltage { get; set; }

        /// <summary>
        /// Запрос на изменение свойств комнаты
        /// </summary>
        /// <param name="newArea"></param>
        /// <param name="newGasConnected"></param>
        /// <param name="newVoltage"></param>
        /// <param name="newName"></param>
        public UpdateRoomQuery(int? newArea, bool? newGasConnected, int? newVoltage, string? newName)
        {
            NewName = newName;
            NewArea = newArea;
            NewGasConnected = newGasConnected;
            NewVoltage = newVoltage;
        }

    }
}

