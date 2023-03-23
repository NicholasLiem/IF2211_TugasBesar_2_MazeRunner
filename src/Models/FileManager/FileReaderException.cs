using System;

namespace Maze.Models
{
  public class UnknownSymbolReading : Exception
  {
    public UnknownSymbolReading() : base("Simbol tidak dikenali! Pembacaan Map Gagal") { }
  }

  public class UnkownFileReading : Exception
  {
    public UnkownFileReading() : base("File tidak ditemukan! Pembacaan Map Gagal") { }
  }
}