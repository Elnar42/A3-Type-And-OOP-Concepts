class LibraryItem
  attr_reader :title, :author, :publication_year

  def initialize(title, author, publication_year)
    @title = title
    @author = author
    @publication_year = publication_year
  end

  def display_info
    puts "Title: #{title}"
    puts "Author: #{author}"
    puts "Publication Year: #{publication_year}"
  end
end

class Book < LibraryItem
  attr_reader :genre

  def initialize(title, author, publication_year, genre)
    super(title, author, publication_year)
    @genre = genre
  end

  def display_info
    puts "Book"
    super
    puts "Genre: #{genre}"
  end
end

class DVD < LibraryItem
  attr_reader :director

  def initialize(title, author, publication_year, director)
    super(title, author, publication_year)
    @director = director
  end

  def display_info
    puts "DVD"
    super
    puts "Director: #{director}"
  end
end

class CD < LibraryItem
  attr_reader :artist

  def initialize(title, author, publication_year, artist)
    super(title, author, publication_year)
    @artist = artist
  end

  def display_info
    puts "CD"
    super
    puts "Artist: #{artist}"
  end
end
