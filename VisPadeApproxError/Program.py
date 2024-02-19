from tkinter import END
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

## read data
data = pd.read_csv("../results_disused/logpade_result.csv")

ns = 6

x, n, error = data["x"].to_numpy(), data["n"].to_numpy(), data["error(log10)"].to_numpy()

x = x.reshape((-1, ns))
n = n.reshape((-1, ns))
error = error.reshape((-1, ns))

## error x=1
plt.clf()
plt.figure(figsize=(12, 5))

approx = n[-1, :] * -1.531 + 0.9639

plt.plot(n[-1, :], error[-1, :], color="black", label="error")
plt.plot(n[-1, :], approx, color="red", label="$ -1.531 n + 0.9639 $", linestyle="dashed", linewidth=1)

plt.xlabel("pade terms (=$n$)")
plt.ylabel("relative error (log10)")

plt.xlim([10, 500])
plt.ylim([-750, 0])

plt.legend(loc="upper right")

plt.grid()

plt.savefig("../figures/logpade_error_x1.svg", bbox_inches='tight', pad_inches=0.1)

## error each terms
plt.clf()
plt.figure(figsize=(12, 5))

for i, n in zip(range(ns), [16, 32, 64, 128, 256, 512]):
    plt.plot(x[:, i], error[:, i], label = f"terms={n}")
    
plt.xlabel("$x$")
plt.ylabel("relative error (log10)")

plt.xlim([0, 1])
plt.ylim([-1200, 0])

plt.xticks(np.arange(11) / 10)

plt.grid()

plt.legend(loc="lower right", ncol=2)

plt.savefig("../figures/logpade_error_terms.svg", bbox_inches='tight', pad_inches=0.1)

## log pade 44
plt.clf()
plt.figure(figsize=(12, 5))

x = np.linspace(0, 1, 513, endpoint=True)[1:]
expected = np.log1p(x) / x
approx44 = (420 + x * (510 + x * (140 + x * (3)))) / (420 + x * (720 + x * (360 + x * (48))))

plt.plot(x, expected, label="expected", color="black")
plt.plot(x, approx44, label="pade[4, 4]", color="red", linestyle="dashed", linewidth=1)

plt.xlabel("$x$")

plt.xlim([0, 1])

plt.xticks(np.arange(11) / 10)

plt.legend(loc="upper right")

plt.grid()

plt.savefig("../figures/logpade_result_44.svg", bbox_inches='tight', pad_inches=0.1)