from flask import Flask, render_template
app = Flask(__name__)

@app.route('/play')
def index():
  return render_template('index.html', number = 3
  )

@app.route('/play/<int:number>')
def play_x(number):
  return render_template('index.html', number = number)

@app.route('/play/<int:number>/<input>')
def play_x_input(number, input):
  return render_template('index.html', number = number, input = input)

if __name__=="__main__":    
    app.run(debug=True)