class Counter
    def initialize(name)
        @name = name
        @count = 0
    end

    def increment
        @count += 1
    end

    def reset 
        @count = 0
    end

    def getName
        @name
    end
    def setName=(value)
        @name = value
    end

    def getTicks
        @count
    end
end

class Clock
    def initialize
        @hours = Counter.new("hours")
        @minutes = Counter.new("minutes")
        @seconds = Counter.new("seconds")
    end

    def ticking 
        if @seconds.getTicks < 59
            @seconds.increment
        else
            if @minutes.getTicks < 59
                @minutes.increment
                @seconds.reset
            else
                if @hours.getTicks < 23
                    @hours.increment
                    @minutes.reset
                    @seconds.reset
                else
                    resetting
                end
            end
        end
    end

    def timeDisplaying
        return  "#{"%02d" % [@hours.getTicks]}:#{"%02d" % [@minutes.getTicks]}:#{"%02d" % [@seconds.getTicks]}"
    end

    def resetting
        @hours.reset
        @minutes.reset
        @seconds.reset
    end

    def getTime 
        self.timeDisplaying 
    end
end

myClock = Clock.new()
puts myClock.getTime
for i in (1..60*60*24-1)
    myClock.ticking
end
puts myClock.getTime

